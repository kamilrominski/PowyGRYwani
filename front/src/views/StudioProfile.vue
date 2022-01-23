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

              <hr />

              <div class="row">
                <div class="col">
                  <div class="card-profile-stats d-flex justify-content-center">
                    <b class="pr-1">Gry studia:</b>
                    <router-link
                      v-for="game in model.games"
                      class="pr-1"
                      :key="game.id"
                      :to="{ name: 'game', params: { id: game.id } }"
                      >{{ game.name }},
                    </router-link>
                  </div>
                </div>
              </div>

              <div class="row float-right">
                <router-link
                  v-if="isUser()"
                  :to="{ name: 'studioEdit', params: { id: 'new' } }"
                  class="btn btn-primary mt-2"
                >
                  Dodaj studio
                </router-link>

                <router-link
                  v-if="isAdmin()"
                  :to="{ name: 'studioEdit', params: { id: model.id } }"
                  class="btn btn-info mt-2"
                >
                  Edytuj studio
                </router-link>

                <button
                  v-if="isAdmin()"
                  class="btn btn-danger mt-2"
                  @click="deleteStudio"
                >
                  Usuń studio
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
  name: "studio-profile",
  data() {
    return {
      model: {
        name: "",
        description: "",
        games: [],
      },
    };
  },
  methods: {
    getStudio() {
      this.axios.get(`/studios/${this.$route.params.id}`).then((studio) => {
        this.model = { ...this.model, ...studio.data };
      });
    },
    deleteStudio() {
      if (confirm("Potwierdź usunięcie")) {
        this.axios.delete(`/studios/${this.$route.params.id}`).then(() => {
          this.$router.push({ name: "search" });
        });
      }
    },
    isUser,
    isAdmin,
  },
  created() {
    this.getStudio();
  },
};
</script>
<style></style>
