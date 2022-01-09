import { createRouter, createWebHashHistory } from "vue-router";

import DashboardLayout from "@/layout/DashboardLayout";
import AuthLayout from "@/layout/AuthLayout";

import Profile from "../views/UserProfile.vue";
import ProfileEdit from "../views/UserProfileEdit.vue";

import Login from "../views/Login.vue";
import Register from "../views/Register.vue";

import GameProfile from "../views/GameProfile.vue";
import GameEdit from "../views/GameEdit.vue";

import StudioProfile from "../views/StudioProfile.vue";
import StudioEdit from "../views/StudioEdit.vue";

import Search from "../views/SearchPage.vue";

const routes = [
  {
    path: "/",
    redirect: "/search",
    component: DashboardLayout,
    children: [
      {
        path: "/profile/:id",
        name: "profile",
        components: { default: Profile },
      },
      {
        path: "/profileEdit/:id",
        name: "profileEdit",
        components: { default: ProfileEdit },
      },
      {
        path: "/studio/:id",
        name: "studio",
        components: { default: StudioProfile },
      },
      {
        path: "/studioEdit/:id",
        name: "studioEdit",
        components: { default: StudioEdit },
      },
      {
        path: "/game/:id",
        name: "game",
        components: { default: GameProfile },
      },
      {
        path: "/gameEdit/:id",
        name: "gameEdit",
        components: { default: GameEdit },
      },
      {
        path: "/search",
        name: "search",
        components: { default: Search },
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
