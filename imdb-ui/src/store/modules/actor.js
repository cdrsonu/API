import axios from "axios";

const state = {
    actors: [],
};

const getters = {
    getActors(state) {
        return state.actors;
    },
};

const mutations = {
    initActors(state, actors) {
        state.actors = actors;
    },
    addActor(state, actor) {
        state.actors.push(actor);
    },
    updateActor(state, { actor, id }) {
        let index = state.actors.findIndex((a) => a.id === id);
        actor.id = id;
        state.actors.splice(index, 1, actor);
    },
    deleteActor(state, id) {
        const index = state.actors.findIndex((a) => a.id === id);
        state.actors.splice(index, 1);
    },
};

const actions = {
    initActors({ commit }) {
        axios
            .get("/actor")
            .then((response) => {
                // console.log(response.data);
                commit("initActors", response.data);
            })
            .catch((error) => {
                console.log(error.message);
            });
    },
    addActor({ commit }, actor) {
        return new Promise((resolve, reject) => {
            axios
                .post("/actor", actor)
                .then((response) => {
                    actor.id = response.data;
                    commit("addActor", actor);
                    resolve(actor.id);
                })
                .catch((error) => {
                    reject(error);
                });
        });
    },
    updateActor({ commit, dispatch }, { actor, id }) {
        axios
            .put(`/actor/${id}`, actor)
            .then(() => {
                commit("updateActor", { actor, id });
                dispatch("initMovies");
            })
            .catch((error) => {
                console.log(error.message);
            });
    },
    deleteActor({ commit }, id) {
        axios
            .delete(`/actor/${id}`)
            .then(() => {
                commit("deleteActor", id);
            })
            .catch((error) => {
                console.log(error.message);
            });
    },
};

export default {
    state,
    getters,
    mutations,
    actions,
};
