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
              <h6 class="heading-small text-muted mb-4">Informacje o serii</h6>
              <div class="pl-lg-4">
                <div class="row">
                  <div class="col-lg-6">
                    <base-input
                      alternative=""
                      label="Nazwa"
                      input-classes="form-control-alternative"
                      v-model="model.name"
                    />
                  </div>
                </div>

                <div class="row">
                  <div class="col-lg-12 mb-3">
                    <label class="form-control-label">Opis</label>
                    <textarea
                      v-model="model.description"
                      class="form-control"
                      rows="3"
                    />
                  </div>
                </div>

                <a class="btn btn-info" @click.prevent="submit">
                  {{ isEdit ? "Edytuj serię" : "Dodaj serię" }}
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
  name: "user-profile",
  data() {
    return {
      model: {
        name: "",
        description: "",
      },
    };
  },

  computed: {
    isEdit() {
      return this.$route.params.id !== "new";
    },
  },

  methods: {
    getSeries() {
      this.axios.get(`/series/${this.$route.params.id}`).then((series) => {
        this.model = { ...this.model, ...series.data };
      });
    },

    submit() {
      if (this.isEdit) {
        this.axios
          .put(`/series/${this.$route.params.id}`, this.model)
          .then(() => {
            alert("Studio zaktualizowe");
          });
      } else {
        this.axios.post(`/series`, this.model).then((series) => {
          this.$router.push({ name: "series", params: { id: series.data.id } });
        });
      }
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
      this.getSeries();
    }
  },
};
</script>
<style></style>
