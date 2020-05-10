function dl() {
    var interval = 5000;
    var l = jQuery('.-download-zip');
    var funcs = [];
    function createDlFunc(i) {
        return function () {
            setTimeout( function() {
            try{ 
                console.log("Clicking " + i + " on " + l[i]);
                l[i].click();
            } 
            catch(e){} 
        }, interval * i);
        }
    }
    for(i = 0; i < l.length; i++) 
    { 
        funcs[i] = createDlFunc(i);
    }
    funcs[l.length] = function() {
        setTimeout(function() {
            jQuery('.next.page-numbers')[0].click();
        }, interval * l.length);
    }
    for(i = 0; i < funcs.length; i++) 
    { 
        console.log("Executing function " + i );
        funcs[i]();
    }
};dl();