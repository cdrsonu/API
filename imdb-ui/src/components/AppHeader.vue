<template>
    <Menu mode="horizontal" theme="dark" active-name="1">
        <div class="layout-logo" style="cursor: pointer">
            <router-link to="/">
                <img alt="Vue logo" src="../assets/imdb-logo.png" id="logo" />
            </router-link>
        </div>
        <div class="layout-nav">
            <MenuItem name="2" class="menu-txt">
                <Icon type="md-log-in" />
                <span>Login</span>
            </MenuItem>
        </div>
    </Menu>
</template>

<script>
export default {
    name: "AppHeader",
};
</script>

<style scoped>
.layout-logo {
    width: 100px;
    height: 30px;
    background: #5b6270;
    border-radius: 3px;
    float: left;
    position: relative;
    top: 7px;
    left: -25px;
}

#logo {
    width: 100px;
    height: 50px;
    margin-bottom: 50px;
}

.layout-nav {
    width: 150px;
    margin: 0 10px 0 auto;
}
.menu-txt {
    font-size: large;
    font-weight: 500;
}
</style>
