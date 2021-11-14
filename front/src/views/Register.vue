<template>
  <div class="row justify-content-center">
    <div class="col-lg-5 col-md-7">
      <div class="card bg-secondary shadow border-0">
        <div class="card-body px-lg-5 py-lg-5">
          <form role="form">
            <base-input
              formClasses="input-group-alternative"
              placeholder="Email"
              addon-left-icon="ni ni-email-83"
              v-model="model.email"
              focused
            >
            </base-input>

            <base-input
              formClasses="input-group-alternative"
              placeholder="Hasło"
              type="password"
              addon-left-icon="ni ni-lock-circle-open"
              v-model="model.password"
            >
            </base-input>

            <base-input
              formClasses="input-group-alternative"
              placeholder="Powtórz hasło"
              type="password"
              addon-left-icon="ni ni-lock-circle-open"
              v-model="model.password2"
            >
            </base-input>

            <!-- Disabled for now -->
            <!-- <div class="text-muted font-italic">
              <small
                >password strength:
                <span class="text-success font-weight-700">strong</span></small
              >
            </div> -->

            <div class="row my-4"></div>
            <div class="text-center">
              <base-button type="primary" class="my-4">
                Stwórz konto
              </base-button>
            </div>
          </form>
        </div>
      </div>
      <div class="row mt-3">
        <div class="col-6">
          <router-link to="/login" class="text-light">
            <small>Zaloguj się na swoje konto</small>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "register",
  data() {
    return {
      model: {
        email: "",
        password2: "",
      },
    };
  },
};
</script>
<style></style>
