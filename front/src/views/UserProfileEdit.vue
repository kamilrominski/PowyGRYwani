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
              <h6 class="heading-small text-muted mb-4">
                Informacje o użytkowniku
              </h6>
              <div class="pl-lg-4">
                <div class="row">
                  <div class="col-lg-6">
                    <base-input
                      alternative=""
                      label="Imię"
                      input-classes="form-control-alternative"
                      v-model="model.name"
                    />
                  </div>
                  <div class="col-lg-6">
                    <base-input
                      alternative=""
                      label="Nazwisko"
                      input-classes="form-control-alternative"
                      v-model="model.surname"
                    />
                  </div>
                </div>

                <div class="row">
                  <div class="col-lg-6">
                    <base-input
                      alternative=""
                      label="Email"
                      input-classes="form-control-alternative"
                      v-model="model.email"
                    />
                  </div>
                </div>
                <a href="#!" class="btn btn-info" @click.prevent="submit"
                  >Edytuj profil</a
                >
              </div>
            </form>
          </card>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "user-profile",
  data() {
    return {
      model: {
        email: "",
        name: "",
        surname: "",
      },
    };
  },

  methods: {
    getProfile() {
      this.axios.get(`/users/${this.$route.params.id}`).then((profile) => {
        this.model = { ...this.model, ...profile.data };
      });
    },
    submit() {
      this.axios.put(`/users/${this.$route.params.id}`, this.model).then(() => {
        alert("Profil zaktualizowany");
      });
    },
  },

  created() {
    this.getProfile();
  },
};
</script>
<style></style>
