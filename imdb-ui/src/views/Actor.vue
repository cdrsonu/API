<template>
    <b-container>
        <b-row>
            <app-person-card
                v-for="actor in actors"
                :key="actor.id"
                :person="actor"
                :title="'Actor'"
            >
            </app-person-card>
        </b-row>
    </b-container>
</template>
<script>
import { mapGetters } from "vuex";
import PersonCard from "@/components/PersonCard";

export default {
    name: "Actor",
    components: {
        appPersonCard: PersonCard,
    },
    data() {
        return {
            title: "Actor",
        };
    },
    computed: {
        ...mapGetters({
            actors: "getActors",
        }),
    },
};
</script>

<style scoped></style>
