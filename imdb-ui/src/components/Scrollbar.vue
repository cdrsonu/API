<template>
    <div>
        <Card id="cardHeading">
            <h3>Up Next</h3>
        </Card>
        <Scroll :on-reach-edge="handleReachEdge" :height="'500'" id="scrollbar">
            <Card
                dis-hover
                v-for="(movie, index) in movies"
                :key="index"
                :class="{ selected: index === value, card: true }"
            >
                <span @click="cardSelected(index)">
                    {{ movie.name }}({{ movie.yearOfRelease }})
                </span>
            </Card>
        </Scroll>
    </div>
</template>
<script>
import { mapGetters } from "vuex";

export default {
    name: "Scrollbar",
    props: ["value"],
    data() {
        return {
            movieList: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
        };
    },
    computed: {
        ...mapGetters({
            movies: "getMovies",
        }),
    },
    methods: {
        cardSelected(index) {
            this.$emit("changeSlide", index);
        },
        handleReachEdge(dir) {
            return new Promise((resolve) => {
                setTimeout(() => {
                    if (dir > 0) {
                        const first = this.movieList[0];
                        for (let i = 1; i < 11; i++) {
                            this.movieList.unshift(first - i);
                        }
                    } else {
                        const last = this.movieList[this.movieList.length - 1];
                        for (let i = 1; i < 11; i++) {
                            this.movieList.push(last + i);
                        }
                    }
                    resolve();
                }, 2000);
            });
        },
    },
};
</script>

<style scoped>
#scrollbar {
    width: 100%;
    max-width: 400px;
    background-image: linear-gradient(#818597, #5c6c6c);
    font-weight: 500;
    font-size: large;
    font-family: Georgia, monospace;
    text-align: justify;
    margin: 0 auto;
}
.card {
    font-size: large;
    text-align: justify;
    cursor: pointer;
    background-image: linear-gradient(#515a6e, #262a2a);
    color: white;
}

.selected {
    background-image: linear-gradient(#394555, #0c5e5e);
    color: white;
}
#cardHeading {
    width: 95%;
    font-weight: 500;
    font-size: large;
    font-family: Georgia, monospace;
    text-align: justify;
    color: white;
    background-image: linear-gradient(#515a6e, #262a2a);
    /*margin-left: 10px;*/
}
</style>
