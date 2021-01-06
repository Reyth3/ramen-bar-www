var j = null;

(function ($) {

	"use strict";

	var fullHeight = function() {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function(){
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();
	j = $;


})(jQuery);

function toggleSidebar() {
		$('#sidebar').toggleClass('active');
}