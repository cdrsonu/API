<template>
    <Modal v-model="show" width="500" class="app-modal">
        <p slot="header" style="text-align: center">
            <Icon type="md-person-add" size="20" /> &nbsp;
            <span>{{ prefix }} {{ title }}</span>
        </p>
        <Form :model="person" ref="personForm" :rules="ruleValidate">
            <FormItem prop="name">
                <Input v-model="person.name" placeholder="Name"> </Input>
            </FormItem>
            <FormItem prop="dob">
                <DatePicker
                    type="date"
                    format="yyyy/MM/dd"
                    placeholder="Date Of Birth"
                    v-model="person.dob"
                >
                </DatePicker>
            </FormItem>
            <FormItem placeholder="Gender" prop="gender">
                <Select v-model="person.gender">
                    <Option value="" disabled>Gender</Option>
                    <Option value="Male">Male</Option>
                    <Option value="Female">Female</Option>
                    <Option value="Others">Others</Option>
                </Select>
            </FormItem>
            <FormItem prop="bio">
                <Input
                    type="textarea"
                    v-model="person.bio"
                    placeholder="Biography"
                >
                </Input>
            </FormItem>
        </Form>
        <div slot="footer">
            <Button
                type="primary"
                :style="{ width: '45%' }"
                @click="submit('personForm', title)"
                >Submit
            </Button>
            <Button
                type="primary"
                @click="formReset()"
                :style="{ width: '45%', marginLeft: '10%' }"
                >Reset
            </Button>
        </div>
    </Modal>
</template>

<script>
import { mapActions } from "vuex";

export default {
    name: "PersonModal",
    props: ["showModal", "title", "data", "editMode"],
    data() {
        const validateDob = (rule, value, callback) => {
            if (value > new Date() || value < new Date("01/01/1600")) {
                callback(new Error("Invalid date of birth"));
            } else {
                callback();
            }
        };
        return {
            person: {
                name: "",
                bio: "",
                gender: "",
                dob: "",
            },
            show: false,
            prefix: "Add ",
            ruleValidate: {
                name: [
                    {
                        required: true,
                        message: "Please enter the name.",
                        trigger: "blur",
                    },
                ],
                bio: [
                    {
                        required: true,
                        message: "Please enter the biography",
                        trigger: "blur",
                    },
                ],
                gender: [
                    {
                        required: true,
                        message: "Please select the gender",
                        trigger: "change",
                    },
                ],

                dob: [
                    {
                        type: "date",
                        required: true,
                        message: "Please enter the Year of Release",
                        trigger: "blur",
                    },
                    { validator: validateDob, trigger: "blur" },
                ],
            },
        };
    },
    watch: {
        showModal() {
            this.show = this.showModal;
            if (this.editMode) {
                if (this.data != null) {
                    this.prefix = "Edit ";
                    this.person.name = this.data.name;
                    this.person.bio = this.data.bio;
                    this.person.dob = this.data.dob;
                    this.person.gender = this.data.gender;
                }
            }
        },
        show() {
            if (this.show === false) {
                this.$emit("hideModal", this.show);
            }
        },
    },
    methods: {
        ...mapActions([
            "initActors",
            "addActor",
            "updateActor",
            "initProducers",
            "addProducer",
            "updateProducer",
        ]),
        formReset() {
            this.person.name = "";
            this.person.bio = "";
            this.person.gender = "";
            this.person.dob = "";
        },
        submit(name, title) {
            let isValid = false;
            this.$refs[name].validate((valid) => {
                if (valid) {
                    this.$Message.success("Success!");
                    isValid = true;
                } else {
                    this.$Message.error("Fail!");
                }
            });
            const person = {
                name: this.person.name,
                bio: this.person.bio,
                dob: this.person.dob,
                gender: this.person.gender,
            };
            if (isValid) {
                if (title === "Actor") {
                    if (this.editMode) {
                        this.updateActor({ actor: person, id: this.data.id });
                    } else {
                        this.addActor(person)
                            .then((id) => {
                                this.$emit("newActorAdded", id);
                            })
                            .catch((error) => {
                                console.log(error.message);
                            });
                    }
                } else if (title === "Producer") {
                    if (this.editMode) {
                        this.updateProducer({
                            producer: person,
                            id: this.data.id,
                        });
                    } else {
                        this.addProducer(person)
                            .then((id) => {
                                this.$emit("newProducerAdded", id);
                            })
                            .catch((error) => {
                                console.log(error.message);
                            });
                    }
                }
                this.formReset();
                this.show = false;
            }
        },
    },
};
</script>

<style scoped>
.app-modal {
    background-image: linear-gradient(#515a6e, #262a2a);
}
</style>
