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
              <h6 class="heading-small text-muted mb-4">User information</h6>
              <div class="pl-lg-4">
                <div class="row">
                  <div class="col-lg-6">
                    <base-input
                      alternative=""
                      label="Nazwa użytkownika"
                      placeholder="Username"
                      input-classes="form-control-alternative"
                      v-model="model.username"
                    />
                  </div>
                  <div class="col-lg-6">
                    <base-input
                      alternative=""
                      label="Email address"
                      placeholder="jesse@example.com"
                      input-classes="form-control-alternative"
                      v-model="model.email"
                    />
                  </div>
                </div>
                <div class="row">
                  <div class="col-lg-6">
                    <base-input
                      alternative=""
                      label="First name"
                      placeholder="First name"
                      input-classes="form-control-alternative"
                      v-model="model.firstName"
                    />
                  </div>
                  <div class="col-lg-6">
                    <base-input
                      alternative=""
                      label="Last name"
                      placeholder="Last name"
                      input-classes="form-control-alternative"
                      v-model="model.lastName"
                    />
                  </div>
                </div>
                <a href="#!" class="btn btn-info">Edit profile</a>
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
        username: "",
        email: "",
        firstName: "",
        lastName: "",
      },
    };
  },
};
</script>
<style></style>
