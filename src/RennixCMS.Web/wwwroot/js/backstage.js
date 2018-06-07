var topBarVm = new Vue({
    el: '#topbar',
    data: function () {
        return {
           
        };
    },
    methods: {
        onLogout: () => {
            var me = this;
            Vue.http.get(cms.urls.logout)
                .then((res) => {
                    if (res.body.success)
                        location.href = cms.pages.login;
                    else
                        me.$alert('注销失败' + err.body.error_meessage);
                })
                .catch((err) => {
                    me.$alert('注销失败'+err.body.error_meessage);
                })
        },
        onModifyPassword: () => {
            location.href = cms.pages.resetPassword;
        }
    }
})

var leftMenuVm = new Vue({
    el: '#left-menu',
    data: function () {
        return {
            
        };
    },
    methods: {
        handleOpen(key, keyPath) {
            console.log(key, keyPath);
        },
        handleClose(key, keyPath) {
            console.log(key, keyPath);
        }
    }
})
