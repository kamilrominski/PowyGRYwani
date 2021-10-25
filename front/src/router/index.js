import { createRouter, createWebHashHistory } from "vue-router";

import DashboardLayout from "@/layout/DashboardLayout";
import AuthLayout from "@/layout/AuthLayout";

import Profile from "../views/UserProfile.vue";
import ProfileEdit from "../views/UserProfileEdit.vue";

import Login from "../views/Login.vue";
import Register from "../views/Register.vue";

const routes = [
  {
    path: "/",
    redirect: "/profile",
    component: DashboardLayout,
    children: [
      {
        path: "/profile",
        name: "profile",
        components: { default: Profile },
      },
      {
        path: "/profileEdit",
        name: "profileEdit",
        components: { default: ProfileEdit },
      },
      {
        path: "/studio",
        name: "studio",
        components: { default: Profile },
      },
      {
        path: "/studioEdit",
        name: "studioEdit",
        components: { default: ProfileEdit },
      },
      {
        path: "/game",
        name: "game",
        components: { default: Profile },
      },
      {
        path: "/gameEdit",
        name: "gameEdit",
        components: { default: ProfileEdit },
      },
    ],
  },
  {
    path: "/",
    redirect: "login",
    component: AuthLayout,
    children: [
      {
        path: "/login",
        name: "login",
        components: { default: Login },
      },
      {
        path: "/register",
        name: "register",
        components: { default: Register },
      },
    ],
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  linkActiveClass: "active",
  routes,
});

export default router;
