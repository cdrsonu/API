<template>
    <Row :justify="getJustify">
        <Col :lg="16" :xl="16">
            <Carousel
                v-model="value"
                loop
                id="carousel"
                :dots="'none'"
                autoplay
            >
                <CarouselItem v-for="movie in movies" :key="movie.id">
                    <Card :bordered="true" class="card">
                        <h2 slot="title" class="pb-0">{{ movie.name }}</h2>
                        <img :src="movie.coverImage" class="poster" />
                        <p class="mb-1">
                            Release Year: {{ movie.yearOfRelease }}
                        </p>
                        <p class="mb-1">Producer: {{ movie.producer.name }}</p>
                        <p class="mb-1">
                            Genres: {{ getString(movie.genres) }}
                        </p>
                        <p class="mb-1">
                            Actors: {{ getString(movie.actors) }}
                        </p>
                    </Card>
                </CarouselItem>
            </Carousel>
        </Col>
        <Col :lg="8" :xl="8" v-if="currentWidth >= 1000">
            <app-scrollbar
                :value="value"
                @changeSlide="value = $event"
            ></app-scrollbar>
        </Col>
    </Row>
</template>

<script>
import Scrollbar from "@/components/Scrollbar";
import { mapGetters } from "vuex";

export default {
    name: "Home",
    components: {
        appScrollbar: Scrollbar,
    },
    data() {
        return {
            value: 0,
            currentWidth: window.innerWidth,
        };
    },
    computed: {
        ...mapGetters({
            movies: "getMovies",
        }),
        getJustify() {
            return this.currentWidth >= 1000 ? "space-between" : "center";
        },
    },
    methods: {
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
    },
    mounted() {
        window.addEventListener("resize", () => {
            this.currentWidth = window.innerWidth;
        });
    },
};
</script>

<style scoped>
.app-title {
    padding: 0;
    margin: 0;
}
#carousel {
    width: 100%;
    max-height: 70vh;
}

.card {
    width: 100%;
    max-width: 750px;
    max-height: 100%;
    background-image: linear-gradient(#3a4155, #152424);
    font-weight: 500;
    font-size: large;
    font-family: Georgia, monospace;
    text-align: center;
    color: white;
    border-radius: 5%;
}

.poster {
    width: 100%;
    height: 350px;
    margin-right: 20px;
    border-radius: 20px;
}
</style>
