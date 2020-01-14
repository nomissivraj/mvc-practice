var sjModal = {};

(function (self) {


    self.init = function () {
        // If we want to do any init/binds on load or something
        $('#modal-container').addClass('modal-open');

        $('#modal-container').on('click', function (e) {
            if (e.target === $(this)[0]) {
                self.close();
            }
        });
    };

    self.confirm = function (msg, callback) {
        self.init();

        // Use msg to build confirmation box

        var div = $('<div><div>').attr("id", "sjModal"),
            messageCont = $('<div></div>').attr("class", "sjModal__text"),
            message = $('<p></p>').text(msg);
            cancel = $("<button></button>").text("Cancel").attr("class", "btn sjModal__btn sjModal__btn--cancel").attr('onclick', 'sjModal.reject()'),
            confirm = $("<button></button>").text("Confirm").attr("class", "btn sjModal__btn sjModal__btn--confirm").attr('onclick', 'sjModal.accept()');

        // On clicking anything that is not within #sjModal self.close()
        messageCont.append(message);
        div.append(messageCont);
        div.append(cancel);
        div.append(confirm);

        $('#modal-container').append(div);

        self.reject = function () {
            callback(false);
            self.close();
        };

        self.accept = function () {
            callback(true);
            self.close();
        };
        
    };

   
   
 

    self.close = function () {
        $('#modal-container').removeClass('modal-open');
        $('#sjModal').remove();
    };

})(sjModal);