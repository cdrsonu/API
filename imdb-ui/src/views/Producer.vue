<template>
    <b-container>
        <b-row>
            <app-person-card
                v-for="producer in producers"
                :key="producer.id"
                :person="producer"
                :title="'Producer'"
            >
            </app-person-card>
        </b-row>
    </b-container>
</template>
<script>
import { mapGetters } from "vuex";
import PersonCard from "@/components/PersonCard";

export default {
    name: "Producer",
    components: {
        appPersonCard: PersonCard,
    },
    data() {
        return {
            title: "Producer",
        };
    },
    computed: {
        ...mapGetters({
            producers: "getProducers",
        }),
    },
};
</script>

<style scoped></style>
