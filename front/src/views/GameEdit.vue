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
                    />
                  </div>
                  <div class="col-lg-6">
                    <!-- <v-select
                      label="Seria"
                      v-model="model.series_id"
                      :reduce="(studio) => studio.id"
                      :options="series"
                    /> -->
                  </div>
                </div>

                <div class="row">
                  <div class="col-lg-12 mb-3">
                    <label><b>Opis</b></label>
                    <textarea
                      v-model="model.description"
                      class="form-control"
                      rows="3"
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
  components: {},
  data() {
    return {
      // TODO  Get from API
      languages: [
        { name: "PL", id: 25 },
        { name: "DE", id: 26 },
      ],
      platforms: [
        { name: "PS3", id: 43 },
        { name: "PC", id: 73 },
      ],
      tags: [
        { name: "Mrok", id: 73 },
        { name: "RPG", id: 72 },
      ],
      studies: [
        { name: "Super studio", id: 23 },
        { name: "Super studio 2", id: 25 },
      ],
      series: [
        { name: "Animal crossing", id: 22 },
        { name: "Gothic", id: 24 },
      ],

      model: {
        id: 1,
        name: "Gothic 3",
        description:
          "Opis gry Opis gry Opis gry Opis gry Opis gry Opis gry Opis gry Opis gry Opis gry",
        studio_id: 23,
        series_id: 24,
      },
    };
  },
};
</script>