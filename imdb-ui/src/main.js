import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import ViewUI from "view-design";
import "view-design/dist/styles/iview.css";
import locale from "view-design/dist/locale/en-US";
import axios from "axios";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";

// Import Bootstrap an BootstrapVue CSS files (order is important)
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

axios.defaults.baseURL = "https://localhost:44330/api";
import firebase from "firebase/app";
import "firebase/database";
import "firebase/storage";

const firebaseConfig = {
    apiKey: "AIzaSyB4eEin8FDZzZ5xd5DvKEHoXmxqOERsAXI",
    authDomain: "imdb-e3794.firebaseapp.com",
    projectId: "imdb-e3794",
    storageBucket: "imdb-e3794.appspot.com",
    databaseURL: "https://imdb-e3794-default-rtdb.firebaseio.com/",
    messagingSenderId: "360858047098",
    appId: "1:360858047098:web:d93d44306d8500d24f21c3",
};

firebase.initializeApp(firebaseConfig);

Vue.use(ViewUI, {
    transfer: true,
    size: "large",
    capture: false,
    locale,
    select: {
        arrow: "md-arrow-dropdown",
        arrowSize: 20,
    },
});

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

Vue.config.productionTip = false;

new Vue({
    router,
    store,
    render: (h) => h(App),
}).$mount("#app");
