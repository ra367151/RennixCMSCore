// Write your JavaScript code.

var cms = {};
cms.urls = {
    login:'/api/account/login',
    register: '/api/account/register',
    logout: '/api/account/logout',

    post: {
        list:'/api/post/getList'
    },
    category: {
        get:'/api/category/get',
        list: '/api/category/getlist',
        create: '/api/category/create',
        update: '/api/category/update',
        delete:'/api/category/delete',
    }
}

cms.pages = {
    login: '/account/login',
    resetPassword: '/account/resetPassword',
    backstage: {
        post_list: '/post/list',
        post_create: '/post/create',
        post_update: '/post/update',
        post_waste: '/post/waste',
        category_list: '/category/list',
    }
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
cms.util.dataConvert = {};
cms.util.dataConvert.toTree = function (data) {
    // 删除 所有 children,以防止多次调用
    data.forEach(function (item) {
        delete item.children;
    });

    // 将数据存储为 以 id 为 KEY 的 map 索引数据列
    var map = {};
    data.forEach(function (item) {
        map[item.id] = item;
    });

    console.log(map);

    var val = [];
    data.forEach(function (item) {

        // 以当前遍历项，的parentId,去map对象中找到索引的id
        var parent = map[item.parentId];

        // 好绕啊，如果找到索引，那么说明此项不在顶级当中,那么需要把此项添加到，他对应的父级中
        if (parent) {

            (parent.children || (parent.children = [])).push(item);

        } else {
            //如果没有在map中找到对应的索引ID,那么直接把 当前的item添加到 val结果集中，作为顶级
            val.push(item);
        }
    });
    console.log(val);
    return val;
}