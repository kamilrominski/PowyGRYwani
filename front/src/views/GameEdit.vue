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
                      v-model="model.lastName"
                    />
                  </div>
                </div>

                <div class="row">
                  <div class="col-lg-12">
                    <base-input
                      alternative=""
                      label="Opis"
                      input-classes="form-control-alternative"
                      v-model="model.description"
                    />
                  </div>
                </div>
                <a href="#!" class="btn btn-info">Edytuj grę</a>
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
  data() {
    return {
      model: {
        name: "Gothic 3",
        description:
          "Opis gry Opis gry Opis gry Opis gry Opis gry Opis gry Opis gry Opis gry Opis gry",
        studio: { name: "Super studio", id: "23" },
        series: { name: "Gothic", id: "24" },
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
};
</script>
<style></style>
