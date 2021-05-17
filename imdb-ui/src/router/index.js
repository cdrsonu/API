import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";

Vue.use(VueRouter);

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/movie",
        name: "Movie",
        component: () => import("../views/Movie"),
    },
    {
        path: "/actor",
        name: "Actor",
        component: () => import("../views/Actor"),
    },
    {
        path: "/producer",
        name: "Producer",
        component: () => import("../views/Producer"),
    },
    {
        path: "/movie/add",
        name: "Add Movie",
        component: () => import("@/components/MovieForm"),
    },
    {
        path: "/movie/edit/:id",
        name: "Edit Movie",
        component: () => import("@/components/MovieForm"),
    },
    {
        path: "*",
        // redirect: {},
        redirect: "/",
    },
];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

export default router;
