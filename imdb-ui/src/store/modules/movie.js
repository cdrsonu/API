import axios from "axios";

const state = {
    movies: [],
};

const getters = {
    getMovies(state) {
        return state.movies;
    },
};

function getFormattedMovie(getters, movie) {
    return {
        id: movie.id,
        name: movie.name,
        yearOfRelease: movie.yearOfRelease,
        plot: movie.plot,
        actors: getters.getActors.filter((a) => movie.actorIds.includes(a.id)),
        genres: getters.getGenres.filter((g) => movie.genreIds.includes(g.id)),
        producer: getters.getProducers.find((p) => p.id === movie.producerId),
        coverImage: movie.coverImage,
    };
}

const mutations = {
    initMovies(state, movies) {
        state.movies = movies;
    },
    addMovie(state, movie) {
        state.movies.push(getFormattedMovie(this.getters, movie));
    },
    updateMovie(state, movie) {
        let index = state.movies.findIndex((m) => m.id === parseInt(movie.id));
        state.movies.splice(index, 1, getFormattedMovie(this.getters, movie));
    },
    deleteMovie(state, id) {
        let index = state.movies.findIndex((m) => m.id === parseInt(id));
        state.movies.splice(index, 1);
    },
};

const actions = {
    initMovies({ commit }) {
        axios
            .get("/movie")
            .then((response) => {
                commit("initMovies", response.data);
            })
            .catch((error) => {
                console.log(error);
            });
    },
    addMovie({ commit }, movie) {
        axios
            .post("/movie", movie)
            .then((response) => {
                movie.id = response.data.movieId;
                commit("addMovie", movie);
            })
            .catch((error) => {
                console.log(error.message);
            });
    },
    updateMovie({ commit }, { movie, id }) {
        axios
            .put(`/movie/${id}`, movie)
            .then((response) => {
                console.log("Movie updated", response.data);
                movie.id = id;
                commit("updateMovie", movie);
            })
            .catch((error) => {
                console.log(error.message);
            });
    },
    deleteMovie({ commit }, id) {
        axios
            .delete(`/movie/${id}`)
            .then(() => {
                commit("deleteMovie", id);
            })
            .catch((error) => {
                console.log(error);
            });
    },
};

export default {
    state,
    mutations,
    actions,
    getters,
};
