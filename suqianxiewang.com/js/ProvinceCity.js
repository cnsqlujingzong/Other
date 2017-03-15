﻿/**
 * 保存地区信息
 * 数据格式
 * AREA_DATA = [{'pro': '北京', 'cities': {'-1': '北京'}}, {...}]
 * 直辖市存在-1，表示就是直辖市
 */
var AREA_DATA = [{ "pro": "\u5317\u4eac", "cities": { "-1": "\u5317\u4eac", "0": "\u4e1c\u57ce\u533a", "1": "\u897f\u57ce\u533a", "4": "\u671d\u9633\u533a", "5": "\u4e30\u53f0\u533a", "6": "\u77f3\u666f\u5c71\u533a", "7": "\u6d77\u6dc0\u533a", "8": "\u95e8\u5934\u6c9f", "9": "\u623f\u5c71", "10": "\u901a\u5dde", "11": "\u987a\u4e49", "12": "\u660c\u5e73", "13": "\u5927\u5174", "14": "\u5e73\u8c37", "15": "\u6000\u67d4", "16": "\u5bc6\u4e91", "17": "\u5ef6\u5e86" } }, { "pro": "\u4e0a\u6d77", "cities": { "-1": "\u4e0a\u6d77", "0": "\u9ec4\u6d66", "2": "\u5f90\u6c47", "3": "\u957f\u5b81", "4": "\u9759\u5b89", "5": "\u666e\u9640", "6": "\u95f8\u5317", "7": "\u8679\u53e3", "8": "\u6768\u6d66", "9": "\u95f5\u884c", "10": "\u5b9d\u5c71", "11": "\u5609\u5b9a", "12": "\u6d66\u4e1c", "13": "\u91d1\u5c71", "14": "\u677e\u6c5f", "15": "\u9752\u6d66", "17": "\u5949\u8d24", "18": "\u5d07\u660e" } }, { "pro": "\u5929\u6d25", "cities": { "-1": "\u5929\u6d25", "0": "\u548c\u5e73\u533a", "1": "\u4e1c\u4e3d\u533a", "2": "\u6cb3\u4e1c\u533a", "3": "\u897f\u9752\u533a", "4": "\u6cb3\u897f\u533a", "5": "\u6d25\u5357\u533a", "6": "\u5357\u5f00\u533a", "7": "\u5317\u8fb0\u533a", "8": "\u6cb3\u5317\u533a", "9": "\u6b66\u6e05\u533a", "10": "\u7ea2\u6865\u533a", "14": "\u5b81\u6cb3", "15": "\u9759\u6d77", "16": "\u5b9d\u577b", "17": "\u84df\u53bf", "18": "\u6ee8\u6d77\u65b0\u533a" } }, { "pro": "\u91cd\u5e86", "cities": { "-1": "\u91cd\u5e86", "0": "\u4e07\u5dde", "1": "\u6daa\u9675", "2": "\u6e1d\u4e2d", "3": "\u5927\u6e21\u53e3", "4": "\u6c5f\u5317", "5": "\u6c99\u576a\u575d", "6": "\u4e5d\u9f99\u5761", "7": "\u5357\u5cb8", "8": "\u5317\u789a", "9": "\u4e07\u76db", "10": "\u53cc\u6322", "11": "\u6e1d\u5317", "12": "\u5df4\u5357", "13": "\u9ed4\u6c5f", "14": "\u957f\u5bff", "15": "\u7da6\u6c5f", "16": "\u6f7c\u5357", "17": "\u94dc\u6881 ", "18": "\u5927\u8db3", "19": "\u8363\u660c", "20": "\u74a7\u5c71", "21": "\u6881\u5e73", "22": "\u57ce\u53e3", "23": "\u4e30\u90fd", "24": "\u57ab\u6c5f", "25": "\u6b66\u9686", "26": "\u5fe0\u53bf", "27": "\u5f00\u53bf", "28": "\u4e91\u9633", "29": "\u5949\u8282", "30": "\u5deb\u5c71", "31": "\u5deb\u6eaa", "32": "\u77f3\u67f1", "33": "\u79c0\u5c71", "34": "\u9149\u9633", "35": "\u5f6d\u6c34", "36": "\u6c5f\u6d25", "37": "\u5408\u5ddd", "38": "\u6c38\u5ddd", "39": "\u5357\u5ddd" } }, { "pro": "\u6cb3\u5317", "cities": ["\u77f3\u5bb6\u5e84", "\u90af\u90f8", "\u90a2\u53f0", "\u4fdd\u5b9a", "\u5f20\u5bb6\u53e3", "\u627f\u5fb7", "\u5eca\u574a", "\u5510\u5c71", "\u79e6\u7687\u5c9b", "\u6ca7\u5dde", "\u8861\u6c34"] }, { "pro": "\u5c71\u897f", "cities": ["\u592a\u539f", "\u5927\u540c", "\u9633\u6cc9", "\u957f\u6cbb", "\u664b\u57ce", "\u6714\u5dde", "\u5415\u6881", "\u5ffb\u5dde", "\u664b\u4e2d", "\u4e34\u6c7e", "\u8fd0\u57ce"] }, { "pro": "\u5185\u8499\u53e4", "cities": ["\u547c\u548c\u6d69\u7279", "\u5305\u5934", "\u4e4c\u6d77", "\u8d64\u5cf0", "\u547c\u4f26\u8d1d\u5c14\u76df", "\u963f\u62c9\u5584\u76df", "\u901a\u8fbd", "\u5174\u5b89\u76df", "\u4e4c\u5170\u5bdf\u5e03\u76df", "\u9521\u6797\u90ed\u52d2\u76df", "\u5df4\u5f66\u6dd6\u5c14\u76df", "\u9102\u5c14\u591a\u65af"] }, { "pro": "\u8fbd\u5b81", "cities": ["\u6c88\u9633", "\u5927\u8fde", "\u978d\u5c71", "\u629a\u987a", "\u672c\u6eaa", "\u4e39\u4e1c", "\u9526\u5dde", "\u8425\u53e3", "\u961c\u65b0", "\u8fbd\u9633", "\u76d8\u9526", "\u94c1\u5cad", "\u671d\u9633", "\u846b\u82a6\u5c9b"] }, { "pro": "\u5409\u6797", "cities": ["\u957f\u6625", "\u5409\u6797", "\u56db\u5e73", "\u8fbd\u6e90", "\u901a\u5316", "\u767d\u5c71", "\u677e\u539f", "\u767d\u57ce", "\u5ef6\u8fb9"] }, { "pro": "\u9ed1\u9f99\u6c5f", "cities": ["\u54c8\u5c14\u6ee8", "\u9f50\u9f50\u54c8\u5c14", "\u7261\u4e39\u6c5f", "\u4f73\u6728\u65af", "\u5927\u5e86", "\u7ee5\u5316", "\u9e64\u5c97", "\u9e21\u897f", "\u9ed1\u6cb3", "\u53cc\u9e2d\u5c71", "\u4f0a\u6625", "\u4e03\u53f0\u6cb3", "\u5927\u5174\u5b89\u5cad"] }, { "pro": "\u6c5f\u82cf", "cities": ["\u5357\u4eac", "\u9547\u6c5f", "\u82cf\u5dde", "\u5357\u901a", "\u626c\u5dde", "\u76d0\u57ce", "\u5f90\u5dde", "\u8fde\u4e91\u6e2f", "\u5e38\u5dde", "\u65e0\u9521", "\u5bbf\u8fc1", "\u6cf0\u5dde", "\u6dee\u5b89"] }, { "pro": "\u6d59\u6c5f", "cities": ["\u676d\u5dde", "\u5b81\u6ce2", "\u6e29\u5dde", "\u5609\u5174", "\u6e56\u5dde", "\u7ecd\u5174", "\u91d1\u534e", "\u8862\u5dde", "\u821f\u5c71", "\u53f0\u5dde", "\u4e3d\u6c34"] }, { "pro": "\u5b89\u5fbd", "cities": { "0": "\u5408\u80a5", "1": "\u829c\u6e56", "2": "\u868c\u57e0", "3": "\u9a6c\u978d\u5c71", "4": "\u6dee\u5317", "5": "\u94dc\u9675", "6": "\u5b89\u5e86", "7": "\u9ec4\u5c71", "8": "\u6ec1\u5dde", "9": "\u5bbf\u5dde", "10": "\u6c60\u5dde", "11": "\u6dee\u5357", "13": "\u961c\u9633", "14": "\u516d\u5b89", "15": "\u5ba3\u57ce", "16": "\u4eb3\u5dde" } }, { "pro": "\u798f\u5efa", "cities": ["\u798f\u5dde", "\u53a6\u95e8", "\u8386\u7530", "\u4e09\u660e", "\u6cc9\u5dde", "\u6f33\u5dde", "\u5357\u5e73", "\u9f99\u5ca9", "\u5b81\u5fb7"] }, { "pro": "\u6c5f\u897f", "cities": ["\u5357\u660c\u5e02", "\u666f\u5fb7\u9547", "\u4e5d\u6c5f", "\u9e70\u6f6d", "\u840d\u4e61", "\u65b0\u4f59", "\u8d63\u5dde", "\u5409\u5b89", "\u5b9c\u6625", "\u629a\u5dde", "\u4e0a\u9976"] }, { "pro": "\u5c71\u4e1c", "cities": ["\u6d4e\u5357", "\u9752\u5c9b", "\u6dc4\u535a", "\u67a3\u5e84", "\u4e1c\u8425", "\u70df\u53f0", "\u6f4d\u574a", "\u6d4e\u5b81", "\u6cf0\u5b89", "\u5a01\u6d77", "\u65e5\u7167", "\u83b1\u829c", "\u4e34\u6c82", "\u5fb7\u5dde", "\u804a\u57ce", "\u6ee8\u5dde", "\u83cf\u6cfd"] }, { "pro": "\u6cb3\u5357", "cities": ["\u90d1\u5dde", "\u5f00\u5c01", "\u6d1b\u9633", "\u5e73\u9876\u5c71", "\u5b89\u9633", "\u9e64\u58c1", "\u65b0\u4e61", "\u7126\u4f5c", "\u6fee\u9633", "\u8bb8\u660c", "\u6f2f\u6cb3", "\u4e09\u95e8\u5ce1", "\u5357\u9633", "\u5546\u4e18", "\u4fe1\u9633", "\u5468\u53e3", "\u9a7b\u9a6c\u5e97", "\u6d4e\u6e90"] }, { "pro": "\u6e56\u5317", "cities": ["\u6b66\u6c49", "\u5b9c\u660c", "\u8346\u5dde", "\u8944\u6a0a", "\u9ec4\u77f3", "\u8346\u95e8", "\u9ec4\u5188", "\u5341\u5830", "\u6069\u65bd", "\u6f5c\u6c5f", "\u5929\u95e8", "\u4ed9\u6843", "\u968f\u5dde", "\u54b8\u5b81", "\u5b5d\u611f", "\u9102\u5dde", "\u795e\u519c\u67b6"] }, { "pro": "\u6e56\u5357", "cities": ["\u957f\u6c99", "\u5e38\u5fb7", "\u682a\u6d32", "\u6e58\u6f6d", "\u8861\u9633", "\u5cb3\u9633", "\u90b5\u9633", "\u76ca\u9633", "\u5a04\u5e95", "\u6000\u5316", "\u90f4\u5dde", "\u6c38\u5dde", "\u6e58\u897f", "\u5f20\u5bb6\u754c"] }, { "pro": "\u5e7f\u4e1c", "cities": ["\u5e7f\u5dde", "\u6df1\u5733", "\u73e0\u6d77", "\u6c55\u5934", "\u4e1c\u839e", "\u4e2d\u5c71", "\u4f5b\u5c71", "\u97f6\u5173", "\u6c5f\u95e8", "\u6e5b\u6c5f", "\u8302\u540d", "\u8087\u5e86", "\u60e0\u5dde", "\u6885\u5dde", "\u6c55\u5c3e", "\u6cb3\u6e90", "\u9633\u6c5f", "\u6e05\u8fdc", "\u6f6e\u5dde", "\u63ed\u9633", "\u4e91\u6d6e"] }, { "pro": "\u5e7f\u897f", "cities": { "0": "\u5357\u5b81", "1": "\u67f3\u5dde", "2": "\u6842\u6797", "3": "\u68a7\u5dde", "4": "\u5317\u6d77", "5": "\u9632\u57ce\u6e2f", "6": "\u94a6\u5dde", "7": "\u8d35\u6e2f", "8": "\u7389\u6797", "11": "\u8d3a\u5dde", "12": "\u767e\u8272", "13": "\u6cb3\u6c60", "14": "\u6765\u5bbe", "15": "\u5d07\u5de6" } }, { "pro": "\u6d77\u5357", "cities": ["\u6d77\u53e3", "\u4e09\u4e9a", "\u4e09\u6c99", "\u4e94\u6307\u5c71", "\u743c\u6d77", "\u510b\u5dde", "\u6587\u660c", "\u4e07\u5b81", "\u4e1c\u65b9", "\u5b9a\u5b89", "\u5c6f\u660c", "\u6f84\u8fc8", "\u4e34\u9ad8", "\u767d\u6c99", "\u660c\u6c5f", "\u4e50\u4e1c", "\u9675\u6c34", "\u4fdd\u4ead", "\u743c\u4e2d"] }, { "pro": "\u56db\u5ddd", "cities": ["\u6210\u90fd", "\u7ef5\u9633", "\u5fb7\u9633", "\u81ea\u8d21", "\u6500\u679d\u82b1", "\u5e7f\u5143", "\u5185\u6c5f", "\u4e50\u5c71", "\u5357\u5145", "\u5b9c\u5bbe", "\u5e7f\u5b89", "\u8fbe\u5dde", "\u96c5\u5b89", "\u7709\u5c71", "\u7518\u5b5c", "\u51c9\u5c71", "\u6cf8\u5dde", "\u963f\u575d\u5dde", "\u9042\u5b81\u5e02", "\u5df4\u4e2d\u5e02", "\u8d44\u9633\u5e02"] }, { "pro": "\u8d35\u5dde", "cities": ["\u8d35\u9633", "\u516d\u76d8\u6c34", "\u9075\u4e49", "\u5b89\u987a", "\u94dc\u4ec1", "\u9ed4\u897f\u5357", "\u6bd5\u8282", "\u9ed4\u4e1c\u5357", "\u9ed4\u5357"] }, { "pro": "\u4e91\u5357", "cities": ["\u6606\u660e", "\u5927\u7406", "\u66f2\u9756", "\u7389\u6eaa", "\u662d\u901a", "\u695a\u96c4", "\u7ea2\u6cb3", "\u6587\u5c71", "\u666e\u6d31", "\u897f\u53cc\u7248\u7eb3", "\u4fdd\u5c71", "\u5fb7\u5b8f", "\u4e3d\u6c5f", "\u6012\u6c5f", "\u8fea\u5e86", "\u4e34\u6ca7"] }, { "pro": "\u897f\u85cf", "cities": ["\u62c9\u8428", "\u65e5\u5580\u5219", "\u5c71\u5357", "\u6797\u829d", "\u660c\u90fd", "\u963f\u91cc", "\u90a3\u66f2"] }, { "pro": "\u9655\u897f", "cities": ["\u897f\u5b89", "\u5b9d\u9e21", "\u54b8\u9633", "\u94dc\u5ddd", "\u6e2d\u5357", "\u5ef6\u5b89", "\u6986\u6797", "\u6c49\u4e2d", "\u5b89\u5eb7", "\u5546\u6d1b"] }, { "pro": "\u7518\u8083", "cities": ["\u5170\u5dde", "\u5609\u5cea\u5173", "\u91d1\u660c", "\u767d\u94f6", "\u5929\u6c34", "\u9152\u6cc9", "\u5f20\u6396", "\u6b66\u5a01", "\u5b9a\u897f", "\u9647\u5357", "\u5e73\u51c9", "\u5e86\u9633", "\u4e34\u590f", "\u7518\u5357"] }, { "pro": "\u5b81\u590f", "cities": ["\u94f6\u5ddd", "\u77f3\u5634\u5c71", "\u5434\u5fe0", "\u56fa\u539f", "\u4e2d\u536b"] }, { "pro": "\u9752\u6d77", "cities": ["\u897f\u5b81", "\u6d77\u4e1c", "\u6d77\u5357", "\u6d77\u5317", "\u9ec4\u5357", "\u7389\u6811", "\u679c\u6d1b", "\u6d77\u897f"] }, { "pro": "\u65b0\u7586", "cities": ["\u4e4c\u9c81\u6728\u9f50", "\u77f3\u6cb3\u5b50", "\u514b\u62c9\u739b\u4f9d", "\u4f0a\u7281", "\u5df4\u97f3\u90ed\u695e", "\u660c\u5409", "\u514b\u5b5c\u52d2\u82cf\u67ef\u5c14\u514b\u5b5c", "\u535a\u5c14\u5854\u62c9", "\u5410\u9c81\u756a", "\u54c8\u5bc6", "\u5580\u4ec0", "\u548c\u7530", "\u963f\u514b\u82cf", "\u5854\u57ce", "\u963f\u52d2\u6cf0", "\u963f\u62c9\u5c14", "\u56fe\u6728\u8212\u514b", "\u4e94\u5bb6\u6e20", "\u5317\u5c6f", "\u94c1\u95e8\u5173"] }, { "pro": "\u9999\u6e2f", "cities": ["\u9999\u6e2f\u7279\u522b\u884c\u653f\u533a"] }, { "pro": "\u6fb3\u95e8", "cities": ["\u6fb3\u95e8\u7279\u522b\u884c\u653f\u533a"] }, { "pro": "\u53f0\u6e7e", "cities": ["\u53f0\u5317", "\u9ad8\u96c4", "\u53f0\u4e2d", "\u53f0\u5357", "\u5c4f\u4e1c", "\u5357\u6295", "\u4e91\u6797", "\u65b0\u7af9", "\u5f70\u5316", "\u82d7\u6817", "\u5609\u4e49", "\u82b1\u83b2", "\u6843\u56ed", "\u5b9c\u5170", "\u57fa\u9686", "\u53f0\u4e1c", "\u91d1\u95e8", "\u9a6c\u7956", "\u6f8e\u6e56"] }];


(function($){
    /**
    * 省市联动
    * @param {Array} AREA_DATA 地区数组 格式：[{pro: '北京', cities: {-1: 北京, 0: 东城区, ...}},{...}]
    * @param {Object} options 一些配置选项
    * @returns {Object} jQuery对象
    */
    $.fn.citySelect = function(datas,options){
        if(!$.isArray(AREA_DATA)) return;
        var opts = $.extend({
            provinceID: -1,
            cityID: -1,
            isShowDefaultVal: true,
            isDealComArea: false
        }, options);
        var $province = $(this).find('select').eq(0);
        var $city = $(this).find('select').eq(1);
        //-1是直辖市信息
        var provicneID = opts.provinceID;
        var cityID = opts.cityID;
        var isShowDefaultVal = opts.isShowDefaultVal;
        var isDealComArea = opts.isDealComArea;
        var defaultData = ['请选择省份', '-2'];
        var tmpArr = [];
  
        //增加下拉项到临时数组
        var addOpt = function(val,text,defVal){
            tmpArr.push("<option value='"+val+"' "+(parseInt(defVal,10)==parseInt(val,10)+''?"selected":"")+">"+text+"</option>");
        };
  
        //省份变更联动城市下拉
        var changeHandler = function(){
            var provinceID = $province.val();
            tmpArr = [];
  
            //非省【请选择】情况下，不显示地市【请选择】
            provinceID == -2 && isShowDefaultVal && addOpt(defaultData[1],defaultData[0]);
            if(provinceID != -2) {
                $.each(AREA_DATA[provinceID]['cities'], function(cid, city) {
                    //是否只显示直辖市
                    if(isDealComArea && provinceID < 4) {
                        addOpt(cityID, AREA_DATA[provinceID]['pro'], cityID);
                        return false;
                    }else {
                        cid != -1 && addOpt(cid, city, cityID);
                    }
                });
            }
            $city.html(tmpArr.join(''));
        };
  
        //初始化省份
        var initProvince = function() {
            tmpArr = [];
            //默认省级下拉
            isShowDefaultVal && addOpt(defaultData[1],defaultData[0]);
            $.each(AREA_DATA, function(pid,details){
                addOpt(pid,details.pro,provicneID);
            });
            $province.html(tmpArr.join(''));
        };
  
        //初始化事件
        var init = function() {
            initProvince();
            //省级联动 控制
            $province.on('change', changeHandler);
            changeHandler();
        }
  
        init();
  
        return this;
    };
}(jQuery));