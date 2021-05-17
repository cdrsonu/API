<template>
    <div>
        <Upload
            :before-upload="handleUpload"
            action="//jsonplaceholder.typicode.com/posts/"
        >
            <Button icon="ios-cloud-upload-outline">
                Select the file to upload
            </Button>
        </Upload>
        <div v-if="file !== null">
            Upload file: {{ file.name }}
            <Button type="text" @click="upload" :loading="loadingStatus">
                {{ loadingStatus ? "Uploading" : "Click to upload" }}
            </Button>
        </div>
    </div>
</template>
<script>
export default {
    data() {
        return {
            file: null,
            loadingStatus: false,
        };
    },
    methods: {
        handleUpload(file) {
            this.file = file;
            return false;
        },
        upload() {
            this.loadingStatus = true;
            setTimeout(() => {
                this.file = null;
                this.loadingStatus = false;
                this.$Message.success("Success");
            }, 1500);
        },
    },
};
</script>
