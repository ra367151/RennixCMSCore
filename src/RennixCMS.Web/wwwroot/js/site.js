// Write your JavaScript code.

var cms = {};
cms.urls = {
    login:'/api/account/login',
    register: '/api/account/register',
    logout: '/api/account/logout',

    post: {
        list:'/api/post/getList'
    }
}

cms.pages = {
    login: '/account/login',
    resetPassword:'/account/resetPassword'
};

// 声明帮助类
cms.util = {};
// queryString帮助类
cms.util.queryString = function() {

    var getQueryString, // 获取所有的queryString
        getQueryStringByName, // 根据key获取queryString
        getQueryStringByIndex  // 根据index获取queryString

    getQueryString = () => {

        var result = location.search.match(new RegExp("[\?\&][^\?\&]+=[^\?\&]+", "g"));

        if (result == null) {

            return "";
        }

        for (var i = 0; i < result.length; i++) {

            result[i] = result[i].substring(1);

        }

        return result;
    }

    //根据QueryString参数名称获取值

    getQueryStringByName = (name) => {

        name = name.toLowerCase();
        
        var result = location.search.toLowerCase().match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));

        if (result == null || result.length < 1) {

            return "";

        }

        return result[1];

    }

    //根据QueryString参数索引获取值

    getQueryStringByIndex = (index) => {

        if (index == null) {

            return "";

        }

        var queryStringList = getQueryString();

        if (index >= queryStringList.length) {

            return "";

        }

        var result = queryStringList[index];

        var startIndex = result.indexOf("=") + 1;

        result = result.substring(startIndex);

        return result;
    }

    return {
        all: getQueryString,
        getByName: getQueryStringByName,
        getByIndex: getQueryStringByIndex
    };
}();