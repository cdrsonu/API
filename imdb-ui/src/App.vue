<template>
    <div id="app" class="layout">
        <Layout>
            <Header>
                <app-header></app-header>
            </Header>
            <app-content></app-content>
            <Footer class="layout-footer-center" :style="{ height: '60px' }">
                Powered by DeltaX &nbsp; &nbsp; &copy; 2021
            </Footer>
        </Layout>
    </div>
</template>

<script>
// @ is an alias to /src
import AppHeader from "@/components/AppHeader";
import AppContent from "@/components/AppContent";
import { mapActions } from "vuex";

export default {
    components: {
        appHeader: AppHeader,
        appContent: AppContent,
    },
    methods: {
        ...mapActions([
            "initMovies",
            "initActors",
            "initProducers",
            "initGenres",
        ]),
    },
    created() {
        this.initMovies();
        this.initActors();
        this.initProducers();
        this.initGenres();
    },
};
</script>

<style scoped>
.layout {
    border: 1px solid #d7dde4;
    background: #f5f7f9;
    position: relative;
    border-radius: 4px;
    overflow: hidden;
}

.layout-footer-center {
    text-align: center;
    background: #515a6e;
    color: white;
}
</style>
