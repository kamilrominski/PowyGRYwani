<template>
  <div>
    <base-header class="header pb-8 pt-5 pt-lg-8 d-flex align-items-center">
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
        <div class="col-12 mb-5 mb-xl-0">
          <div class="card card-profile shadow">
            <div class="row justify-content-center">
              <div class="col-lg-3 order-lg-2">
                <div class="card-profile-image">
                  <img src="img/theme/game.jpg" class="rounded-circle" />
                </div>
              </div>
            </div>
            <div
              class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4"
            >
              <div class="d-flex justify-content-between"></div>
            </div>
            <div class="card-body pt-0 pt-md-4">
              <div class="row">
                <div class="col">
                  <div
                    class="card-profile-stats d-flex justify-content-center mt-md-5"
                  ></div>
                </div>
              </div>
              <div class="text-center">
                <h2>
                  {{ model.name }}
                  <span class="font-weight-light">
                    [{{ model.platforms.map((p) => p.name).join(",") }}]
                  </span>
                </h2>

                <hr />

                <h3>
                  Studio:
                  <router-link
                    class="font-weight-light"
                    :to="{ name: 'studio', params: { id: model.studio.id } }"
                  >
                    <span>
                      {{ model.studio.name }}
                    </span>
                  </router-link>
                </h3>

                <h3>
                  Języki:
                  <span class="font-weight-light">
                    {{ model.languages.map((p) => p.name).join(",") }}
                  </span>
                </h3>

                <h3>
                  Tagi:
                  <span class="font-weight-light">
                    {{ model.tags.map((p) => p.name).join(",") }}
                  </span>
                </h3>

                <h3>
                  Seria:
                  <router-link
                    class="font-weight-light"
                    :to="{ name: 'series', params: { id: model.series.id } }"
                  >
                    <span>
                      {{ model.series.name }}
                    </span>
                  </router-link>
                </h3>

                <h3>
                  Opis:
                  <p>{{ model.description }}</p>
                </h3>
              </div>
              <div class="row float-right">
                <router-link
                  v-if="isUser()"
                  :to="{ name: 'gameEdit', params: { id: 'new' } }"
                  class="btn btn-primary mt-2"
                >
                  Dodaj grę
                </router-link>

                <router-link
                  v-if="isAdmin()"
                  :to="{ name: 'gameEdit', params: { id: model.id } }"
                  class="btn btn-info mt-2"
                >
                  Edytuj grę
                </router-link>

                <button
                  v-if="isAdmin()"
                  class="btn btn-danger mt-2"
                  @click="deleteGame"
                >
                  Usuń grę
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { isUser, isAdmin } from "../components/authUtils";
export default {
  data() {
    return {
      model: {
        name: "[Brak]",
        description: "[Brak]",
        studio: { name: "[Brak]", id: "new" },
        series: { name: "[Brak]", id: "new" },
        languages: [
          { name: "PL", id: "25" },
          { name: "DE", id: "26" },
        ],
        platforms: [
          { name: "PS3", id: "43" },
          { name: "PC", id: "73" },
        ],
        tags: [
          { name: "Mrok", id: "73" },
          { name: "RPG", id: "72" },
        ],
      },
    };
  },
  methods: {
    getGame() {
      this.axios.get(`/games/${this.$route.params.id}`).then((game) => {
        this.model = { ...this.model, ...game.data };

        this.axios.get(`/studios/${game.data.studio_id}`).then((studio) => {
          this.model.studio = studio.data;
        });

        this.axios.get(`/series/${game.data.series_id}`).then((series) => {
          this.model.series = series.data;
        });
      });
    },
    deleteGame() {
      if (confirm("Potwierdź usunięcie")) {
        this.axios.delete(`/games/${this.$route.params.id}`).then(() => {
          this.$router.push({ name: "search" });
        });
      }
    },
    isUser,
    isAdmin,
  },
  created() {
    this.getGame();
  },
};
</script>
<style></style>
