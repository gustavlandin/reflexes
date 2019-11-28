﻿using System;
using Xunit;
using Moq;
using reflexes.Controller;
using reflexes.Model;
using reflexes.View;

namespace reflexesTest
{
    public class MainControllerTest
    {

        [Fact]
        public void MainController_NewMainControllerShouldReturnMainController()
        {
            var reflexGame = new ReflexGameImplemented();
            var consoleView = new ConsoleViewImplemented();
            var levelController = new LevelControllerImplemented(reflexGame, consoleView);
            var mainController = new MainController(reflexGame, consoleView, levelController);

            Assert.IsType<MainController>(mainController);
        }

        [Fact]
        public void RunApplication_ShouldCallGetAction()
        {
            var mockReflexGame = new Mock<ReflexGame>();
            var mockConsoleView = new Mock<ConsoleView>();
            var mockLevelController = new Mock<LevelController>();

            var mainController = new MainController(mockReflexGame.Object, mockConsoleView.Object, mockLevelController.Object);
            mockConsoleView.Setup(view => view.GetAction()).Returns(4);

            mainController.RunApplication();
            mockConsoleView.Verify(view => view.GetAction(), Times.Once());
        }




    }
}
