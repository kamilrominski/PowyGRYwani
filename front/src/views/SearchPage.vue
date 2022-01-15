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
      <page-visits-table class="" />
    </div>
  </div>
</template>
<script>
import PageVisitsTable from "./Dashboard/PageVisitsTable.vue";
export default {
  components: { PageVisitsTable },
};
</script>
<style></style>
