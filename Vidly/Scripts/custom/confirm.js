var sjModal = {};

(function (self) {


    self.init = function () {
        // If we want to do any init/binds on load or something
        $('#modal-container').addClass('modal-open');
    };

    self.confirm = function (target, msg, callback) {
        self.init();

        // Use msg to build confirmation box

        var div = $('<div><div>').attr("id", "sjModal"),
            message = $('<p></p>').text(msg);
            cancel = $("<button></button>").text("Cancel").attr('onclick', 'sjModal.reject()'),
            confirm = $("<button></button>").attr('onclick', 'sjModal.accept()').text("Confirm");
        // On clicking anything that is not within #sjModal self.close()
        div.append(message);
        div.append(cancel);
        div.append(confirm);

        $('#modal-container').append(div);


        // get result from box

        // IF SUCCESS CALLBACK
        callback();
    };

    self.reject = function () {
        self.close();
        console.log("reject");
    };

    self.accept = function () {
        self.close();
        console.log("accept");
    };

    self.close = function () {
        $('#modal-container').removeClass('modal-open');
        $('#sjModal').remove();
    };

})(sjModal);