//#region accordion1
$(document).ready(function () {
  $("#accordion-1 .paragraphs")
    .find(".title")
    .mouseover(function () {
      if ($(this).next().css("display") === "none") {
        $(this).css({
          transition: "all 0.2s ease-out",
          background: "#f34f3f",
        });
        $(this).find("h6").css({ color: "#ffffff" });
        $(this).find("i").css({ color: "#ffffff" });
      }
    });

  $("#accordion-1 .paragraphs")
    .find(".title")
    .mouseleave(function () {
      if ($(this).next().css("display") === "none") {
        $(this).css({
          transition: "all 0.2s ease-out",
          background: "#ffffff",
        });
        $(this).find("h6").css({ color: "#1b1b1b" });
        $(this).find("i").css({ color: "#1b1b1b" });
      }
    });

  $("#accordion-1 .paragraphs")
    .first()
    .find(".title")
    .click(function () {
      if ($(this).next().css("display") === "none") {
        $(this).css({
          transition: "all 0.2s ease-out",
          background: "#f34f3f",
        });
        $(this).find("h6").css({ color: "#ffffff" });
        $(this).find("i").css({ color: "#ffffff" });
        $(this).find("i").removeClass("fas fa-minus");
        $(this).find("i").addClass("fas fa-plus");
      } else {
        $(this).css({
          transition: "all 0.2s ease-out",
          background: "#ffffff",
        });
        $(this).find("h6").css({ color: "#1b1b1b" });
        $(this).find("i").css({ color: "#1b1b1b" });
        $(this).find("i").removeClass("fas fa-plus");
        $(this).find("i").addClass("fas fa-minus");
      }

      $(this).next().slideToggle(400);
      $("#accordion-1 .paragraphs")
        .first()
        .find(".content")
        .not($(this).next())
        .slideUp(500);
    });

  $("#accordion-1 .paragraphs")
    .last()
    .find(".title")
    .click(function () {
      if ($(this).next().css("display") === "none") {
        $(this).css({
          transition: "all 0.3s ease-out",
          background: "#f34f3f",
        });
        $(this).find("i").removeClass("fas fa-plus");
        $(this).find("i").addClass("fas fa-minus");
        $(this).find("h6").css({ color: "#ffffff" });
        $(this).find("i").css({ color: "#ffffff" });
      } else {
        $(this).css({
          transition: "all 0.3s ease-out",
          background: "#ffffff",
        });
        $(this).find("i").removeClass("fas fa-plus");
        $(this).find("i").addClass("fas fa-minus");
        $(this).find("h6").css({ color: "#1b1b1b" });
        $(this).find("i").css({ color: "#1b1b1b" });

      }

      $(this).next().slideToggle(400);
      $("").last().find(".content").not($(this).next()).slideUp(400);
    });
});
//#endregion

//#region accordion2
$(document).ready(function () {
  $("#accordion-2 .paragraphs")
    .find(".title")
    .mouseover(function () {
      if ($(this).next().css("display") === "none") {
        $(this).find("h6").css({
          color: "#f34f3f",
          transition: "all 0.3s",
        });
        $(this).find("i").css({
          color: "#f34f3f",
          transition: "all 0.3",
        });
      }
    });

  $("#accordion-2 .paragraphs")
    .find(".title")
    .mouseleave(function () {
      if ($(this).next().css("display") === "none") {
        $(this).find("h6").css({
          color: "#1b1b1b",
          transition: "all 0.3s",
        });
        $(this).find("i").css({
          color: "#1b1b1b",
          transition: "all 0.3s",
        });
      }
    });

  $("#accordion-2 .paragraphs")
    .first()
    .find(".title")
    .click(function () {
      if ($(this).next().css("display") === "none") {
        $(this).find("h6").css({
          color: "#f34f3f",
          transition: "all 0.3s",
        });
        $(this).find("i").css({
          color: "#f34f3f",
          transition: "all 0.3s",
        });
      }

      $(this).next().slideToggle(500);
      $("#accordion-2 .paragraphs")
        .first()
        .find(".content")
        .not($(this).next())
        .slideUp(500);
    });

  $("#accordion-2 .paragraphs")
    .last()
    .find(".title")
    .click(function () {
      if ($(this).next().css("display") === "none") {
        $(this).find("h6").css({
          color: "#f34f3f",
          transition: "all 0.3s",
        });
        $(this).find("i").css({
          color: "#f34f3f",
          transition: "all 0.3s",
        });
      }
      $(this).next().slideToggle(500);
      $("#accordion-2 .paragraphs")
        .last()
        .find(".content")
        .not($(this).next())
        .slideUp(500);
    });
});
//#endregion
