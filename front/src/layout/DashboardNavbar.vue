<template>
  <base-nav
    class="navbar-top navbar-dark"
    id="navbar-main"
    :show-toggle-button="false"
    expand
  >
    <form
      class="navbar-search navbar-search-dark form-inline mr-3 d-none d-md-flex ml-lg-auto"
    >
      <div class="form-group mb-0">
        <base-input
          placeholder="Szukaj"
          class="input-group-alternative"
          alternative=""
          addon-right-icon="fas fa-search"
        >
        </base-input>
      </div>
    </form>
    <ul class="navbar-nav align-items-center d-none d-md-flex">
      <li class="nav-item dropdown">
        <router-link
          v-if="!displayName"
          style="color: white"
          :to="{ name: 'login' }"
        >
          <i class="ni ni-single-02 mr-2"></i>
          <span>Zaloguj się</span>
        </router-link>
        <base-dropdown v-else class="nav-link pr-0">
          <template v-slot:title>
            <div v class="media align-items-center">
              <span class="avatar avatar-sm rounded-circle">
                <img
                  alt="Image placeholder"
                  src="img/theme/team-4-800x800.jpg"
                />
              </span>
              <div class="media-body ml-2 d-none d-lg-block">
                <span class="mb-0 text-sm font-weight-bold">
                  {{ displayName }}
                </span>
              </div>
            </div>
          </template>
          <div class="dropdown-header noti-title">
            <h6 class="text-overflow m-0">Witaj!</h6>
          </div>
          <router-link :to="`/profile/${id}`" class="dropdown-item">
            <i class="ni ni-single-02"></i>
            <span>Mój profil</span>
          </router-link>
          <div class="dropdown-divider"></div>
          <a class="dropdown-item" @click.prevent="logout">
            <i class="ni ni-user-run"></i>
            <span>Wyloguj się</span>
          </a>
        </base-dropdown>
      </li>
    </ul>
  </base-nav>
</template>
<script>
export default {
  data() {
    return {
      activeNotifications: false,
      showMenu: false,
      searchQuery: "",
      displayName: "",
      userId: "",
    };
  },
  methods: {
    toggleSidebar() {
      this.$sidebar.displaySidebar(!this.$sidebar.showSidebar);
    },
    hideSidebar() {
      this.$sidebar.displaySidebar(false);
    },
    toggleMenu() {
      this.showMenu = !this.showMenu;
    },
    logout() {
      localStorage.setItem("name", "");
      localStorage.setItem("surname", "");
      localStorage.setItem("id", null);
      localStorage.setItem("isAdmin", false);
      this.$router.push({ name: "login" });
    },
  },
  created() {
    const name = localStorage.getItem("name");
    const surname = localStorage.getItem("surname");
    this.id = localStorage.getItem("id");

    if (name && surname) {
      this.displayName = `${name} ${surname}`;
    }
  },
};
</script>

<style scoped>
.input-group-alternative {
  color: red !important;
}
</style>
