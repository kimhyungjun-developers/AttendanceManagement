import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Home from "../components/pages/AttendanceDetail.vue"; //TODO indexページ変更

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/attendancedetail",
    name: "attendancedetail",
    component: () =>
      import(
        /* webpackChunkName: "attendancedetail" */ "../components/pages/AttendanceDetail.vue"
      ),
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
