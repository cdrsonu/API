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
                        <i>{{ person.name }}</i>
                    </span>
                </div>
            </template>
            <b-card-text class="">
                <p class="app-text">{{ person.gender }}</p>
                <p class="app-text">{{ getFormattedDob(person.dob) }}</p>
            </b-card-text>
            <template #footer>
                <b-button
                    variant="secondary"
                    block
                    class="card-btn app-text"
                    @click="edit"
                >
                    Edit
                </b-button>
                <b-button
                    variant="secondary"
                    block
                    class="card-btn app-text"
                    @click="remove"
                >
                    Delete
                </b-button>
            </template>
        </b-card>
        <app-person-modal
            :title="title"
            :showModal="showModal"
            :data="person"
            :editMode="true"
            @hideModal="showModal = $event"
        >
        </app-person-modal>
    </b-col>
</template>

<script>
import PersonModal from "@/components/PersonModal";

export default {
    name: "PersonCard",
    props: ["person", "title"],
    components: {
        appPersonModal: PersonModal,
    },
    data() {
        return {
            showModal: false,
        };
    },
    methods: {
        getFormattedDob(dob) {
            let dt = new Date(dob);
            const options = {
                year: "numeric",
                month: "long",
                day: "numeric",
            };
            return dt.toLocaleDateString("en-IN", options);
        },
        view() {
            this.$Modal.info({
                title: this.title + " Info",
                content: `Name：${this.person.name}<br>
                          Biography: ${this.person.bio}`,
            });
        },
        edit() {
            this.showModal = true;
        },
        remove() {
            this.$bvModal
                .msgBoxConfirm("Are you sure to delete?", {
                    title: `${this.person.name}`,
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
                        this.title === "Actor"
                            ? this.$store.dispatch(
                                  "deleteActor",
                                  this.person.id
                              )
                            : this.$store.dispatch(
                                  "deleteProducer",
                                  this.person.id
                              );
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
