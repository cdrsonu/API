<template>
    <b-col cols="12" md="6" lg="4" class="mt-4">
        <b-card
            text-variant="white"
            footer-tag="footer"
            header-tag="header"
            class="text-center"
            style="background-image: linear-gradient(#515a6e, #262a2a)"
        >
            <template #header>
                <div class="d-flex justify-content-between align-items-center">
                    <b-icon
                        icon="info-circle-fill"
                        scale="2"
                        variant="white"
                        @click="view"
                        style="cursor: pointer"
                    ></b-icon>
                    <span class="mb-0 app-title">
                        <i>{{ movie.name }}</i>
                    </span>
                </div>
            </template>
            <b-card-text class="">
                <p class="app-text">Release Year: {{ movie.yearOfRelease }}</p>
                <p class="app-text">Producer: {{ movie.producer.name }}</p>
                <p class="app-text">Genres: {{ getString(movie.genres) }}</p>
                <p class="app-text">Actors: {{ getString(movie.actors) }}</p>
            </b-card-text>
            <template #footer>
                <b-button block class="card-btn app-text" @click="edit">
                    Edit
                </b-button>
                <b-button block class="card-btn app-text" @click="remove">
                    Delete
                </b-button>
                <b-container>
                    <b-row> </b-row>
                </b-container>
            </template>
        </b-card>
    </b-col>
</template>

<script>
import { mapActions } from "vuex";

export default {
    name: "MovieCard",
    props: ["movie"],
    data() {
        return {};
    },
    methods: {
        ...mapActions(["deleteMovie"]),
        getString(data) {
            let result = "";
            let i = data.length;
            data.forEach((a) => {
                if (i > 1) {
                    result += a.name + ", ";
                } else {
                    result += a.name;
                }
                i--;
            });
            return result;
        },
        view() {
            this.$Modal.info({
                title: "Movie Info",
                content: `Name：${this.movie.name}<br>
                          Description: ${this.movie.plot}`,
            });
        },
        edit() {
            const id = this.movie.id;
            this.$router.push({
                path: `/movie/edit/${id}`,
            });
        },
        remove() {
            this.$bvModal
                .msgBoxConfirm("Are you sure to delete?.", {
                    title: `${this.movie.name}`,
                    size: "md",
                    buttonSize: "md",
                    okVariant: "danger",
                    okTitle: "YES",
                    cancelTitle: "NO",
                    footerClass: "p-2",
                    hideHeaderClose: true,
                    centered: true,
                })
                .then((value) => {
                    if (value) {
                        this.deleteMovie(this.movie.id);
                    }
                })
                .catch((err) => {
                    console.log(err.message);
                });
        },
    },
};
</script>

<style scoped>
.card-btn {
    width: 40%;
    font-weight: 525;
    font-style: italic;
    box-sizing: content-box;
    background-image: linear-gradient(#515a6e, #262a2a);
}

.app-text {
    font-weight: 500;
    font-size: large;
    font-family: Georgia, monospace;
    color: whitesmoke;
}
.app-title {
    font-weight: 500;
    font-size: x-large;
    font-family: Georgia, monospace;
    color: whitesmoke;
}
</style>
