using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tic_Tac_Toe;
using Tic_Tac_Toe.Controllers;
using Tic_Tac_Toe.Models;

namespace Tic_Tac_Toe.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IsGameOverTest()
        {
            var sut = new TicTacToeGame();
            var actual = sut.IsGameOver;

            Assert.AreEqual(false, actual);
        }       

        [TestMethod]
        public void CheckWinner()
        {

            var sut = new TicTacToeGame();

            var actual = sut.DoesPlayerWinWithPlay('X',8); 

            Assert.AreEqual(false, actual);

        }
        
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
