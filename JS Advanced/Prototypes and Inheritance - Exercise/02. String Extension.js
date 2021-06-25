(function solve() {
    String.prototype.ensureStart = function (str) {
        if (this.toString().startsWith(str)) {
            return this.toString();
        } else {
            return str + this.toString();
        }
    };

    String.prototype.ensureEnd = function (str) {
        if (this.toString().endsWith(str)) {
            return this.toString();
        } else {
            return this.toString() + str;
        }
    };

    String.prototype.isEmpty = function () {
        if (this.length == 0) {
            return true;
        } else {
            return false;
        }
    }

    String.prototype.truncate = function (n) {
        if (n <= 3) {
            return ".".repeat(n);
        }
        if (this.toString().length <= n) {
            return this.toString();
        } else {
            let lastIndex = this.toString().substr(0, n - 2).lastIndexOf(" ");
            if (lastIndex != -1) {
                return this.toString().substr(0, lastIndex) + "...";
            } else {
                return this.toString().substr(0, n - 3) + "...";
            }
        }
    };
    String.format = function (string, ...params) {
        for (let i = 0; i < params.length; i++) {
            let index = string.indexOf("{" + i + "}");
            while (index != -1) {
                string = string.replace("{" + i + "}", params[i]);
                index = string.indexOf("{" + i + "}");
            }
        }
        return string;
    };

})();
let str = 'my string';
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
str = str.truncate(4);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
str = String.format('jumps {0} {1}',
    'dog');

