<template>
  <div class="row justify-content-center" style="min-height: 55vh">
    <div class="col-lg-5 col-md-7">
      <div class="card bg-secondary shadow border-0">
        <div class="card-body px-lg-5 py-lg-5">
          <form @submit.prevent="login">
            <base-input
              formClasses="input-group-alternative mb-3"
              placeholder="Email"
              addon-left-icon="ni ni-email-83"
              v-model="model.email"
            >
            </base-input>

            <base-input
              formClasses="input-group-alternative mb-3"
              placeholder="Hasło"
              type="password"
              addon-left-icon="ni ni-lock-circle-open"
              v-model="model.password"
            >
            </base-input>

            <div class="text-center">
              <base-button type="primary" class="my-4" @click="login">
                Zaloguj się
              </base-button>
            </div>
          </form>
        </div>
      </div>
      <div class="row mt-3">
        <div class="col-6">
          <router-link to="/register" class="text-light">
            <small>Stwórz konto</small>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      model: {
        email: "",
        password: "",
      },
    };
  },
  methods: {
    login() {
      this.axios
        .get(`/users/${this.model.email}/${this.model.password}`)
        .then((user) => {
          localStorage.setItem("name", user.data.name);
          localStorage.setItem("surname", user.data.surname);
          localStorage.setItem("isAdmin", user.data.isAdmin);
          localStorage.setItem("id", user.data.id);

          this.$router.push({ name: "profile", params: { id: user.data.id } });
        })
        .catch(() => {
          alert("Zły login lub hasło");
        });
    },
  },
};
</script>
<style></style>
