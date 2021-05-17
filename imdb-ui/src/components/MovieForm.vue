<template>
    <Row :wrap="true" :justify="'space-around'">
        <Col :md="{ span: 24 }" :lg="11" id="image-container">
            <div>
                <Upload
                    :before-upload="uploadImage"
                    :format="['jpg', 'jpeg', 'png']"
                    action=""
                    :style="{ cursor: 'pointer' }"
                >
                    <img
                        :src="movie.coverImage"
                        alt="CoverImage"
                        height="425px"
                        :width="100"
                        class="poster"
                    />
                    <strong
                        v-if="file === null"
                        :style="{
                            display: 'inline-block',
                            width: '100%',
                            height: '10px',
                        }"
                        class="app-text"
                    >
                        <i>{{ getImageTitle }}</i>
                    </strong>
                </Upload>
                <div v-if="file !== null">
                    <strong class="app-text"
                        ><i>Selected file: {{ file.name }}</i></strong
                    >
                    <Progress
                        :percent="progress"
                        :stroke-width="20"
                        text-inside
                    />
                </div>
            </div>
        </Col>
        <Col
            :sm="24"
            :md="{ span: 24, marginTop: '50px' }"
            :lg="{ span: 11, offset: '1' }"
            :style="{ paddingRight: '10px' }"
        >
            <Form
                ref="MovieForm"
                :model="movie"
                :rules="ruleValidate"
                :label-width="80"
                :style="{ width: '100%', margin: '20px auto' }"
            >
                <FormItem label="Title" prop="name">
                    <Input v-model="movie.name" placeholder="Enter the title">
                    </Input>
                </FormItem>
                <FormItem label="Release" prop="yearOfRelease">
                    <Input
                        type="number"
                        v-model="movie.yearOfRelease"
                        placeholder="Enter year of release"
                        number
                    >
                    </Input>
                </FormItem>
                <FormItem label="Plot" prop="plot">
                    <Input
                        v-model="movie.plot"
                        type="textarea"
                        :autosize="{ minRows: 4, maxRows: 5 }"
                        placeholder="Enter the plot..."
                    >
                    </Input>
                </FormItem>
                <FormItem label="Actors" prop="actorIds">
                    <Row>
                        <Col span="21">
                            <Select
                                v-model="movie.actorIds"
                                placeholder="Select the actors"
                                multiple
                                filterable
                            >
                                <Option
                                    v-for="actor in actors"
                                    :value="actor.id"
                                    :key="actor.id"
                                    >{{ actor.name }}
                                </Option>
                            </Select>
                        </Col>
                        <Col span="2" offset="1">
                            <Button
                                size="large"
                                icon="ios-add-circle-outline"
                                type="default"
                                shape="circle"
                                class="embedded-btn app-text"
                                @click.prevent="addActor()"
                            ></Button>
                        </Col>
                    </Row>
                </FormItem>
                <FormItem label="Producer" prop="producerId">
                    <Row>
                        <Col span="21">
                            <Select
                                v-model="movie.producerId"
                                placeholder="Select the producer"
                                filterable
                            >
                                <Option
                                    v-for="producer in producers"
                                    :value="producer.id"
                                    :key="producer.id"
                                    >{{ producer.name }}
                                </Option>
                            </Select>
                        </Col>
                        <Col span="2" offset="1">
                            <Button
                                size="large"
                                icon="ios-add-circle-outline"
                                type="default"
                                shape="circle"
                                class="embedded-btn app-text"
                                @click.prevent="addProducer()"
                            ></Button>
                        </Col>
                    </Row>
                </FormItem>
                <FormItem label="Genre" prop="genreIds">
                    <Select
                        v-model="movie.genreIds"
                        placeholder="Select the genres"
                        multiple
                        filterable
                    >
                        <Option
                            v-for="genre in genres"
                            :value="genre.id"
                            :key="genre.id"
                        >
                            {{ genre.name }}
                        </Option>
                    </Select>
                </FormItem>
                <FormItem>
                    <b-button-group style="width: 100%">
                        <b-button
                            variant="secondary"
                            block
                            class="form-btn app-text"
                            @click.prevent="handleSubmit('MovieForm')"
                        >
                            Submit
                        </b-button>
                        <b-button
                            variant="secondary"
                            block
                            class="form-btn app-text"
                            @click="handleReset('MovieForm')"
                        >
                            Reset
                        </b-button>
                    </b-button-group>
                </FormItem>
            </Form>
        </Col>
        <app-person-modal
            :title="title"
            :showModal="showModal"
            :edit-mode="false"
            @hideModal="showModal = $event"
            @newActorAdded="movie.actorIds.push(Number($event))"
            @newProducerAdded="movie.producerId = Number($event)"
        >
        </app-person-modal>
    </Row>
</template>
<script>
import { mapGetters, mapActions } from "vuex";
import PersonModal from "@/components/PersonModal";
import firebase from "firebase/app";
import axios from "axios";

export default {
    name: "MovieForm",
    components: {
        appPersonModal: PersonModal,
    },
    data() {
        const validateYor = (rule, value, callback) => {
            let currentYear = new Date().getFullYear();
            if (value > currentYear || value < 1600) {
                callback(new Error("Please enter a valid release year"));
            } else {
                callback();
            }
        };
        return {
            name: "MovieForm",
            movie: {
                name: "",
                yearOfRelease: 0,
                plot: "",
                actorIds: [],
                genreIds: [],
                producerId: "",
                coverImage:
                    "https://firebasestorage.googleapis.com/v0/b/imdb-e3794.appspot.com/o/CoverImages%2Fmovie.jpg?alt=media&token=7e6c6c92-8cc2-43da-ae96-35af805c91dc",
            },
            title: "",
            showModal: false,
            file: null,
            progress: 0,
            loadingStatus: false,
            ruleValidate: {
                name: [
                    {
                        required: true,
                        message: "The title cannot be empty",
                        trigger: "blur",
                    },
                ],
                plot: [
                    {
                        required: true,
                        message: "Please enter the plot",
                        trigger: "blur",
                    },
                ],
                yearOfRelease: [
                    {
                        type: "number",
                        required: true,
                        message: "Please enter the Year of Release",
                        trigger: "blur",
                    },
                    { validator: validateYor, trigger: "blur" },
                ],
                actorIds: [
                    {
                        type: "array",
                        required: true,
                        message: "Please select at least one actor",
                        trigger: "blur",
                    },
                ],
                producerId: [
                    {
                        type: "number",
                        required: true,
                        message: "Please select the producer",
                        trigger: "blur",
                    },
                ],
                genreIds: [
                    {
                        type: "array",
                        required: true,
                        message: "Please select at least one genre",
                        trigger: "blur",
                    },
                ],
            },
        };
    },
    computed: {
        ...mapGetters({
            actors: "getActors",
            producers: "getProducers",
            genres: "getGenres",
        }),
        getImageTitle() {
            return this.$router.currentRoute.name === "Add Movie"
                ? "Upload Cover Here"
                : "Wanna Change Cover?";
        },
    },
    methods: {
        ...mapActions(["initMovies", "addMovie", "updateMovie"]),
        uploadImage(file) {
            this.file = file;
            let fileExtension = file.name.split(".")[1];
            let fileName = `${this.movie.name}_${this.movie.yearOfRelease}.${fileExtension}`;
            let imageRef = firebase.storage().ref(`CoverImages/${fileName}`);

            let uploadTask = imageRef.put(file);
            uploadTask.on(
                "state_changed",
                (snapshot) => {
                    this.progress =
                        (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
                },
                (error) => {
                    console.log(error.message);
                },
                () => {
                    imageRef.getDownloadURL().then((url) => {
                        if (this.movie) {
                            this.movie.coverImage = url;
                        }
                    });
                }
            );
            return false;
        },
        handleSubmit(name) {
            let isValid = false;
            this.$refs[name].validate((valid) => {
                if (valid) {
                    this.$Message.success("Success!");
                    isValid = true;
                } else {
                    this.$Message.error("Fail!");
                }
            });
            const movie = {
                name: this.movie.name,
                yearOfRelease: this.movie.yearOfRelease,
                plot: this.movie.plot,
                actorIds: this.movie.actorIds,
                genreIds: this.movie.genreIds,
                producerId: this.movie.producerId,
                coverImage: this.movie.coverImage,
            };
            if (isValid) {
                if (this.$router.currentRoute.name === "Add Movie") {
                    this.addMovie(movie);
                } else if (this.$router.currentRoute.name === "Edit Movie") {
                    const id = this.$route.params.id;
                    this.updateMovie({ movie, id });
                }
                this.$refs[name].resetFields();
                this.$router.push("/movie");
            }
        },
        handleReset(name) {
            this.$refs[name].resetFields();
        },
        addActor() {
            this.title = "Actor";
            this.showModal = true;
        },
        addProducer() {
            this.title = "Producer";
            this.showModal = true;
        },
    },
    mounted() {
        if (this.$router.currentRoute.name === "Edit Movie") {
            this.movie.id = this.$route.params.id;
            axios
                .get(`/movie/${this.movie.id}`)
                .then((response) => {
                    const record = response.data;
                    this.movie.name = record.name;
                    this.movie.yearOfRelease = record.yearOfRelease;
                    this.movie.plot = record.plot;
                    this.movie.actorIds = record.actors.map(
                        (actor) => actor.id
                    );
                    this.movie.genreIds = record.genres.map(
                        (genre) => genre.id
                    );
                    this.movie.producerId = record.producer.id;
                    this.movie.coverImage = record.coverImage;
                    console.log(this.movie);
                })
                .catch((error) => {
                    console.log(error.message);
                });
        }
    },
};
</script>

<style scoped>
.form-btn {
    margin-top: 5px;
    padding: 7px;
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

.embedded-btn {
    font-weight: 525;
    font-style: italic;
    box-sizing: content-box;
    background-image: linear-gradient(#515a6e, #262a2a);
}

#image-container {
    padding: 0 10px;
}

.poster {
    width: 100%;
    min-width: 450px;
    min-height: 450px;
    height: 450px;
    border-radius: 5%;
    align-content: center;
    justify-content: center;
}
</style>
