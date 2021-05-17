<template>
    <div class="layout">
        <Layout :style="{ minHeight: '82.5vh' }">
            <Sider
                ref="side1"
                hide-trigger
                breakpoint="xl"
                :default-collapsed="false"
                collapsible
                v-on:on-collapse="isCollapsed = $event"
                :collapsed-width="80"
                v-model="isCollapsed"
                width="250px"
            >
                <Menu
                    :active-name="title"
                    theme="dark"
                    width="auto"
                    :class="menuitemClasses"
                    v-on:on-select="changeRoute"
                >
                    <MenuItem name="Home" class="menu-text">
                        <Icon type="md-home"></Icon>
                        <span>Home</span>
                    </MenuItem>
                    <MenuItem name="Movie" class="menu-text">
                        <Icon type="md-videocam" />
                        <span>Movie</span>
                    </MenuItem>
                    <MenuItem name="Actor" class="menu-text">
                        <Icon type="md-person"></Icon>
                        <span>Actor</span>
                    </MenuItem>
                    <MenuItem name="Producer" class="menu-text">
                        <Icon type="md-person"></Icon>
                        <span>Producer</span>
                    </MenuItem>
                </Menu>
                <div slot="trigger">Hello</div>
            </Sider>
            <Layout class="layout">
                <Header :style="{ padding: 0 }" class="layout-header-bar">
                    <Row id="page-heading">
                        <Col span="2">
                            <Icon
                                @click.native="collapsedSider"
                                :class="rotateIcon"
                                :style="{
                                    margin: '0 10px 0 20px',
                                    cursor: 'pointer',
                                }"
                                type="ios-arrow-back"
                                size="36"
                            >
                            </Icon>
                        </Col>
                        <Col span="18">
                            {{ title }}
                        </Col>

                        <Col span="4" v-if="showBtn">
                            <Button
                                :size="'large'"
                                icon="ios-add-circle-outline"
                                type="default"
                                ghost
                                id="addBtn"
                                @click="addItem"
                            >
                                Add {{ title }}
                            </Button>
                        </Col>
                    </Row>
                </Header>
                <Content
                    :style="{
                        margin: '25px 25px 0 25px',
                        minHeight: '260px',
                    }"
                >
                    <router-view v-if="title === 'Home'"></router-view>
                    <Scroll :height="'550'" v-else>
                        <router-view></router-view>
                    </Scroll>
                </Content>
            </Layout>
        </Layout>
        <app-person-modal
            :title="title"
            :showModal="showModal"
            :edit-mode="false"
            @hideModal="showModal = $event"
        ></app-person-modal>
    </div>
</template>
<script>
import PersonModal from "@/components/PersonModal";

export default {
    name: "AppContent",
    components: {
        appPersonModal: PersonModal,
    },
    data() {
        return {
            isCollapsed: false,
            title: this.$router.currentRoute.name,
            showModal: false,
        };
    },
    computed: {
        rotateIcon() {
            return ["menu-icon", this.isCollapsed ? "rotate-icon" : ""];
        },
        menuitemClasses() {
            return ["menu-item", this.isCollapsed ? "collapsed-menu" : ""];
        },
        showBtn() {
            return (
                this.title === "Movie" ||
                this.title === "Actor" ||
                this.title === "Producer"
            );
        },
    },
    watch: {
        // eslint-disable-next-line no-unused-vars
        $route(to, from) {
            this.title = this.$router.currentRoute.name;
        },
    },
    methods: {
        collapsedSider() {
            this.$refs.side1.toggleCollapse();
        },
        changeRoute(newRoute) {
            if (this.$router.currentRoute.name !== newRoute) {
                this.$router.push({ name: newRoute });
                this.title = newRoute;
            }
        },
        addItem() {
            if (this.title === "Movie") {
                this.$router.push("/movie/add");
            } else if (this.title === "Actor" || this.title === "Producer") {
                this.showModal = true;
            }
        },
    },
};
</script>

<style scoped>
#page-heading {
    font-weight: 500;
    font-size: 2em;
    color: rgba(253, 251, 251, 0.88);
    background-image: linear-gradient(#515a6e, #262a2a);
    padding-bottom: 10px;
}

#addBtn {
    font-weight: bold;
    font-size: large;
    color: rgba(253, 251, 251, 0.88);
    margin-bottom: 5px;
}

.menu-text {
    font-size: medium;
    font-weight: 500;
}

.layout {
    border: 1px solid #d7dde4;
    /*background: #f5f7f9;*/
    /*background: whitesmoke;*/
    background-image: linear-gradient(white, #969fac);
    position: relative;
    border-radius: 4px;
    overflow: hidden;
}

.layout-header-bar {
    background: #fff;
    box-shadow: 0 1px 1px rgba(0, 0, 0, 0.1);
}

.layout-logo-left {
    width: 90%;
    height: 30px;
    background: #5b6270;
    border-radius: 3px;
    margin: 15px auto;
}

.menu-icon {
    transition: all 0.3s;
}

.rotate-icon {
    transform: rotate(180deg);
}

.menu-item span {
    display: inline-block;
    overflow: hidden;
    width: 80px;
    text-overflow: ellipsis;
    white-space: nowrap;
    vertical-align: bottom;
    transition: width 0.2s ease 0.2s;
    font-weight: 500;
    font-size: large;
    font-family: Georgia, monospace;
    color: whitesmoke;
}

.menu-item i {
    transform: translateX(0px);
    transition: font-size 0.2s ease, transform 0.2s ease;
    vertical-align: middle;
    font-size: 16px;
}

.collapsed-menu span {
    width: 0;
    transition: width 0.2s ease;
}

.collapsed-menu i {
    transform: translateX(5px);
    transition: font-size 0.2s ease 0.2s, transform 0.2s ease 0.2s;
    vertical-align: middle;
    font-size: 22px;
}
</style>
