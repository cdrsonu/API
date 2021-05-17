import Vue from "vue";
import Vuex from "vuex";
import movie from "@/store/modules/movie";
import actor from "@/store/modules/actor";
import producer from "@/store/modules/producer";
import axios from "axios";

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        genres: [],
    },
    getters: {
        getGenres(state) {
            return state.genres;
        },
    },
    mutations: {
        initGenres(state, genres) {
            state.genres = genres;
        },
    },
    actions: {
        initGenres({ commit }) {
            axios
                .get("/genre")
                .then((response) => {
                    commit("initGenres", response.data);
                })
                .catch((error) => console.log(error.message));
        },
    },
    modules: {
        movie,
        actor,
        producer,
    },
});
