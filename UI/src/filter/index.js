import Vue from 'vue';

// format ngày tháng năm để hiển thị lên table
Vue.filter('formatDate', function (dateString) {
    if (dateString !== null) {
        var res = dateString.split("-");
        var year = res[0];
        var month = res[1];
        var day = res[2].split("T")[0];
        return day + "/" + month + "/" + year;
    }
    return "";
});

// format tiền lương
Vue.filter('formatSalary', function (salary) {
    if (salary !== null) {
        return salary.toLocaleString("vi-VN");
    }
    return "";
})