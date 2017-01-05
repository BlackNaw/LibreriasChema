function productItemHeight(element) {
	$(element).each(function() {
		var itemHeight = $(this).height();
		$(this).css({
			"height": itemHeight
		});
	});
}

// $(window).load(function() {
// 	productItemHeight(".product-item");
// });
// // detect a change in a file input with an id of “the-file-input”
// $("#the-file-input").change(function() {
//     // will log a FileList object, view gifs below
//     console.log(this.files);
// });

// render the image in our view
function renderImage(file) {

    // generate a new FileReader object
    var reader = new FileReader();

    // inject an image with the src url
    reader.onload = function(event) {
        the_url = event.target.result;
		alert(the_url.toString());
        $('#some_container_div').html("<img src='" + the_url + "' />")
    };

    // when the file is read it triggers the onload event above.
    reader.readAsDataURL(file);
}

// handle input changes
$("#the-file-input").change(function() {
    console.log(this.files);

    // grab the first image in the FileList object and pass it to the function
    renderImage(this.files[0])
});