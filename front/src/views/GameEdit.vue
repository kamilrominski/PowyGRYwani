<template>
  <div>
    <base-header
      class="header pb-8 pt-5 pt-lg-8 d-flex align-items-center"
      style="background-size: cover; background-position: center top"
    >
      <!-- Mask -->
      <span class="mask bg-gradient-success opacity-8"></span>
      <!-- Header container -->
      <div class="container-fluid d-flex align-items-center">
        <div class="row">
          <div class="col-lg-7 col-md-10"></div>
        </div>
      </div>
    </base-header>

    <div class="container-fluid mt--7">
      <div class="row">
        <div class="col-12">
          <card shadow type="secondary">
            <form>
              <h6 class="heading-small text-muted mb-4">Informacje o grze</h6>
              <div class="pl-lg-4">
                <div class="row">
                  <div class="col-lg-6">
                    <base-input
                      alternative=""
                      label="Nazwa"
                      input-classes="form-control-alternative"
                      v-model="model.name"
                      :required="true"
                      :error="this.model.name.length < 3 && nameError"
                    />
                  </div>
                  <div class="col-lg-6">
                    <base-select
                      :model="model.series_id"
                      label="Seria"
                      :options="series"
                      @update="model.series_id = $event"
                    />
                  </div>
                </div>

                <div class="row">
                  <div class="col-lg-6">
                    <base-select
                      :model="model.studio_id"
                      label="Studio"
                      :options="studios"
                      @update="model.studio_id = $event"
                    />
                  </div>

                  <div class="col-lg-6">
                    <base-checkbox-form
                      label="Język"
                      :options="languages"
                      :model="model.languages_ids"
                      @update="model.languages_ids = $event"
                    />
                  </div>
                </div>

                <div class="row mt-3">
                  <div class="col-lg-6">
                    <base-checkbox-form
                      label="Platforma"
                      :options="platforms"
                      :model="model.platforms_ids"
                      @update="model.platforms_ids = $event"
                    />
                  </div>

                  <div class="col-lg-6">
                    <base-checkbox-form
                      label="Tag"
                      :options="tags"
                      :model="model.tags_ids"
                      @update="model.tags_ids = $event"
                    />
                  </div>
                </div>

                <div class="row">
                  <div class="col-lg-12 mt-3">
                    <label class="form-control-label">Opis</label>
                    <textarea
                      v-model="model.description"
                      class="form-control"
                      rows="3"
                    />
                  </div>
                </div>

                <a href="#!" class="btn btn-info mt-2" @click.prevent="submit">
                  {{ isEdit ? "Edytuj grę" : "Dodaj grę" }}
                </a>
              </div>
            </form>
          </card>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { isAdmin } from "../components/authUtils";
export default {
  data() {
    return {
      // TODO  Get from API
      languages: [
        { name: "PL", id: 25 },
        { name: "DE", id: 26 },
        { name: "CN", id: 27 },
        { name: "ES", id: 28 },
      ],
      platforms: [
        { name: "PS3", id: 43 },
        { name: "PC", id: 73 },
      ],
      tags: [
        { name: "Mrok", id: 73 },
        { name: "RPG", id: 72 },
      ],
      studios: [],
      series: [],
      nameError: "",
      model: {
        name: "",
        description: "",
        studio_id: undefined,
        series_id: undefined,
        languages_ids: [25, 26],
        platforms_ids: [43, 73],
        tags_ids: [73, 72],
      },
    };
  },
  computed: {
    isEdit() {
      return this.$route.params.id !== "new";
    },
  },
  methods: {
    getGame() {
      this.axios.get(`/games/${this.$route.params.id}`).then((game) => {
        this.model = { ...this.model, ...game.data };
      });
    },
    submit() {
      if (this.model.name.length < 3) {
        this.nameError = "Minimalna długość: 3";
        return;
      }

      if (this.isEdit) {
        this.axios
          .put(`/games/${this.$route.params.id}`, this.model)
          .then(() => {
            alert("Gra zaktualizowana");
          });
      } else {
        this.axios.post(`/games`, this.model).then((game) => {
          console.log(game);
          this.$router.push({ name: "game", params: { id: game.data.id } });
        });
      }
    },
    getLists() {
      this.axios.get(`/studios`).then((studios) => {
        this.studios = studios.data;
      });
      this.axios.get(`/series`).then((series) => {
        this.series = series.data;
      });
    },
    checkAuth() {
      if (!isAdmin()) {
        this.$router.push({ name: "login" });
      }
    },
  },

  created() {
    if (this.isEdit) {
      this.checkAuth();
      this.getGame();
    }
    this.getLists();
  },
};
</script>
