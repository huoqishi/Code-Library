function getEncryption(password, uin, vcode, isMd5) {
        var str1 = hexchar2bin(isMd5 ? password : md5(password));
        var str2 = md5(str1 + uin);
        var str3 = md5(str2 + vcode.toUpperCase());
        return str3
    }
//vcode必需，可以避免重放攻击。