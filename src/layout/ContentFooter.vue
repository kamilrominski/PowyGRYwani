<template>
  <footer class="footer px-4">
    <div class="row align-items-center justify-content-lg-between">
      <div class="col-lg-6">
        <div class="copyright text-center text-lg-left text-muted">
          © {{ year }}
          <a
            href="https://gdansk.pja.edu.pl/pl/"
            class="font-weight-bold ml-1"
            target="_blank"
            >PJATK</a
          >
        </div>
      </div>
      <div class="col-lg-6"></div>
    </div>
  </footer>
</template>
<script>
export default {
  data() {
    return {
      year: new Date().getFullYear(),
    };
  },
};
</script>
<style></style>
