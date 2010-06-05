﻿// <auto-generated />
// ReSharper disable InconsistentNaming
#pragma warning disable 169

namespace RedBadger.CloudFolderBackup.Specs
{
    using System.Collections.Generic;

    using Machine.Specifications;

    using RedBadger.CloudFolderBackup.Extensions;

    public abstract class a_Initialised_ICollection
    {
        protected static ICollection<string> collection;

        private Establish context = () => collection = new List<string>();
    }

    [Subject(typeof(ICollection<string>), "IsNullOrEmpty Extension")]
    public class when_empty : a_Initialised_ICollection
    {
        private It should_return_false = () => collection.IsNullOrEmpty().ShouldBeTrue();
    }

    [Subject(typeof(ICollection<string>), "IsNullOrEmpty Extension")]
    public class when_populated : a_Initialised_ICollection
    {
        private Establish context = () => collection.Add("Item");

        private It should_return_true = () => collection.IsNullOrEmpty().ShouldBeFalse();
    }

    [Subject(typeof(ICollection<string>), "IsNullOrEmpty Extension")]
    public class when_null
    {
        private static readonly ICollection<string> collection = null;

        private It should_return_true = () => collection.IsNullOrEmpty().ShouldBeTrue();
    }
}