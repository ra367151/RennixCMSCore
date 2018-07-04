var apis = {};
var pages = {};

pages = {
    post : {
        detail: '/post/detail',
        list:'/post/list',
    }
}

apis = {
    post: {
        getList: '/api/post/getlist',
        get: '/api/post/get'
    }
};

var cleanArray =function (actual) {
    const newArray = []
    for (let i = 0; i < actual.length; i++) {
        if (actual[i]) {
            newArray.push(actual[i])
        }
    }
    return newArray
}

var objectToQueryString = function (json) {
    if (!json) return ''
    return cleanArray(Object.keys(json).map(key => {
        if (json[key] === undefined) return ''
        return encodeURIComponent(key) + '=' +
            encodeURIComponent(json[key])
    })).join('&')
}