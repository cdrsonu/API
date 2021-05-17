<template>
    <b-container>
        <b-row>
            <app-movie-card
                v-for="movie in movies"
                :key="movie.id"
                :movie="movie"
            >
            </app-movie-card>
        </b-row>
    </b-container>
</template>

<script>
import MovieCard from "@/components/MovieCard";
import { mapGetters } from "vuex";

export default {
    components: {
        appMovieCard: MovieCard,
    },
    computed: {
        ...mapGetters({
            movies: "getMovies",
        }),
    },
};
</script>
