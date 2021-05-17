import axios from "axios";

const state = {
    producers: [],
};

const getters = {
    getProducers(state) {
        return state.producers;
    },
};

const mutations = {
    initProducers(state, producers) {
        state.producers = producers;
    },
    addProducer(state, producer) {
        state.producers.push(producer);
    },
    updateProducer(state, { producer, id }) {
        let index = state.producers.findIndex((p) => p.id === id);
        producer.id = id;
        state.producers.splice(index, 1, producer);
    },
    deleteProducer(state, id) {
        const index = state.producers.findIndex((p) => p.id === id);
        state.producers.splice(index, 1);
    },
};

const actions = {
    //actionName(context)  context is same as store
    initProducers({ commit }) {
        axios
            .get("/producer")
            .then((response) => {
                // console.log(response.data);
                commit("initProducers", response.data);
            })
            .catch((error) => {
                console.log(error.message);
            });
    },
    addProducer({ commit }, producer) {
        return new Promise((resolve, reject) => {
            axios
                .post("/producer", producer)
                .then((response) => {
                    producer.id = response.data;
                    commit("addProducer", producer);
                    resolve(producer.id);
                })
                .catch((error) => {
                    reject(error);
                });
        });
    },
    updateProducer({ commit, dispatch }, { producer, id }) {
        axios
            .put(`/producer/${id}`, producer)
            .then(() => {
                commit("updateProducer", { producer, id });
                dispatch("initMovies");
            })
            .catch((error) => {
                console.log(error.message);
            });
    },
    deleteProducer({ commit }, id) {
        axios
            .delete(`/producer/${id}`)
            .then(() => {
                commit("deleteProducer", id);
            })
            .catch((error) => {
                console.log(error.message());
            });
    },
};

export default {
    state,
    getters,
    mutations,
    actions,
};
