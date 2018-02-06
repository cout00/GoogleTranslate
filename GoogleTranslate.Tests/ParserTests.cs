﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTranslate.Core;
using FTranslate.Core.BaseClasses;
using FTranslate.Core.Interfaces;
using FTranslate.Core.ObjectPool;
using FTranslate.Core.Yandex;
using NUnit.Framework;
using Rhino.Mocks;

namespace GoogleTranslate.Tests
{
    [TestFixture]
    public class ParserTests
    {
        IHttpRequest request;
        private Language languageInp;
        private Language languageOutput;
        private string langCode;

        [SetUp]
        public void InitAll()
        {
            request = MockRepository.GenerateStub<IHttpRequest>();
            languageInp = (Language)Pool.SingletonPool.GetPoolObject("Russian");
            languageOutput = (Language)Pool.SingletonPool.GetPoolObject("English");
            langCode = $"{languageInp.GetLanguageCode()}-{languageOutput.GetLanguageCode()}";
            languageInp.Text=String.Empty;
            languageOutput.Text=String.Empty;
        }

        [Test]
        public void TestParser()
        {
            request.Expect(r => r.GetRequestData(langCode, "")).Return("{\"code\":200,\"lang\":\"en - ru\",\"text\":[\"привет мир\"]}");
            YandexParser p = new YandexParser(request, languageInp, languageOutput);
            var result = p.Translate();
            Assert.That(result == null && languageOutput.Text == "привет мир");
        }
        // #region Exceprtions
        [Test]
        public void TestExceprtion42()
        {
            request.Expect(r => r.GetRequestData(langCode, "")).Throw(new NotTranslatedException());
            YandexParser p = new YandexParser(request, languageInp, languageOutput);
            var result = p.Translate();
            Assert.That(result.ExceptionCode == 42 && languageOutput.Text == "");
        }

        [Test]
        public void TestExceprtion300()
        {
            request.Expect(r => r.GetRequestData(langCode, "")).Return("{\"code\":300,\"lang\":\"en - ru\",\"text\":[\"привет мир\"]}");
            YandexParser p = new YandexParser(request, languageInp, languageOutput);
            var result = p.Translate();
            Assert.That(result.ExceptionCode == 300 && languageOutput.Text == "");
        }

        //[Test]
        //public void TestExceprtion401()
        //{
        //    request.Expect(r => r.GetRequestData("")).Return("{\"code\":401,\"lang\":\"en - ru\",\"text\":[\"привет мир\"]}");
        //    YandexParser p = new YandexParser(request, "");
        //    var result = p.GetTranslate();
        //    Assert.That(result.Item1.ExceptionCode == 401 && result.Item2 == "");
        //}

        //[Test]
        //public void TestExceprtion402()
        //{
        //    request.Expect(r => r.GetRequestData("")).Return("{\"code\":402,\"lang\":\"en - ru\",\"text\":[\"привет мир\"]}");
        //    YandexParser p = new YandexParser(request, "");
        //    var result = p.GetTranslate();
        //    Assert.That(result.Item1.ExceptionCode == 402 && result.Item2 == "");
        //}
        //[Test]
        //public void TestExceprtion404()
        //{
        //    request.Expect(r => r.GetRequestData("")).Return("{\"code\":404,\"lang\":\"en - ru\",\"text\":[\"привет мир\"]}");
        //    YandexParser p = new YandexParser(request, "");
        //    var result = p.GetTranslate();
        //    Assert.That(result.Item1.ExceptionCode == 404 && result.Item2 == "");
        //}
        //[Test]
        //public void TestExceprtion413()
        //{
        //    request.Expect(r => r.GetRequestData("")).Return("{\"code\":413,\"lang\":\"en - ru\",\"text\":[\"привет мир\"]}");
        //    YandexParser p = new YandexParser(request, "");
        //    var result = p.GetTranslate();
        //    Assert.That(result.Item1.ExceptionCode == 413 && result.Item2 == "");
        //}
        //[Test]
        //public void TestExceprtion422()
        //{
        //    request.Expect(r => r.GetRequestData("")).Return("{\"code\":422,\"lang\":\"en - ru\",\"text\":[\"привет мир\"]}");
        //    YandexParser p = new YandexParser(request, "");
        //    var result = p.GetTranslate();
        //    Assert.That(result.Item1.ExceptionCode == 422 && result.Item2 == "");
        //}
        //[Test]
        //public void TestExceprtion501()
        //{
        //    request.Expect(r => r.GetRequestData("")).Return("{\"code\":501,\"lang\":\"en - ru\",\"text\":[\"привет мир\"]}");
        //    YandexParser p = new YandexParser(request, "");
        //    var result = p.GetTranslate();
        //    Assert.That(result.Item1.ExceptionCode == 501 && result.Item2 == "");
        //}
        //#endregion

    }
}
