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
                  <img src="img/theme/studio.jpg" class="rounded" />
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
                <h3>
                  {{ model.name }} <br />
                  <span class="font-weight-light">{{ model.description }}</span>
                </h3>
              </div>

              <div class="row float-right">
                <router-link
                  v-if="isAdmin()"
                  :to="{ name: 'seriesEdit', params: { id: model.id } }"
                  class="btn btn-info mt-2"
                >
                  Edytuj serię
                </router-link>

                <router-link
                  v-if="isUser()"
                  :to="{ name: 'seriesEdit', params: { id: 'new' } }"
                  class="btn btn-primary mt-2"
                >
                  Dodaj serię
                </router-link>
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
        name: "",
        description: "",
      },
    };
  },
  methods: {
    getSeries() {
      this.axios.get(`/series/${this.$route.params.id}`).then((series) => {
        this.model = { ...this.model, ...series.data };
      });
    },
    isUser,
    isAdmin,
  },
  created() {
    this.getSeries();
  },
};
</script>
<style></style>
