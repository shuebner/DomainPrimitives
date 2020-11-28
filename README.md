# DomainPrimitives
Base classes and templates for domain primitives in C#. They are not necessarily "good", "complete" or "performant" and may not even consistently follow the approach outlined below. This is just a fiddle to try out ways of making the creation and usage of domain primitives as easy as possible.
I tried documenting the still ongoing journey in my blog with the introductory [My Take On Domain Primitives](https://svenhuebner-it.com/domain-primitives-i-easily-declaring-domain-primitives) and then diving into the code in a series of posts starting with [Domain Primitives I: easily declaring domain primitives](https://svenhuebner-it.com/domain-primitives-i-easily-declaring-domain-primitives).

Beware that the code in the repo and the code in the blog posts may differ because both started independently and are currently being aligned blog post by post.
There are unit tests that fail on purpose to demonstrate invalid approaches.

# Declaration
To declare a domain primitive type with an underlying immutable reference type (most prominently `string`) the `KindOf<T>` base class or one of its specializations (again, most prominentl `KindOfString`) can be used.

Value types are different because we cannot inherit from a base struct. To declare a domain primitive type with an underlying value type (most prominently `int`) the `KindOfIntTemplate` could be made into a code snippet where only the class name and the underlying type need to be specified. Since the template can change, special care would need to be taken to enable migrating existing struct domain primitives to the latest template version (maybe add a region with a machine-parseable name each time the template is changed and then let a script do the changes to existing code).

# Creation
It must be very difficult to create instances fo these domain primitives in an invalid state. Since throwing exceptions from constructors is not transparent and also does not force the caller to catch them, domain primitives should be created through static methods that call a private constructor and return a `CreationResult<T>` that can contain either the successfully constructed instance or an error.

Internal domain error messages must not accidentally show up via API or UI, since they can contain sensitive data that could violate privacy requirements or leak domain logic (think insurance rate calculations etc.). To enable showing proper validation errors in an API or UI, the Error must have a unique error code. The internal error message of the Error is private so that it can only be used for debugging (compiler directive may make sense to not bloat the error objects in production) and cannot accidentally leak to the outside world. Special care must be taken to avoid default value domain primitives that do not represent a valid value. Code analyzers that prohibit the use of default struct constructors can help with that.

To finally create domain objects from your domain primitives at the edges of your domain the same creation pattern could be used. The CreationResults could act similarly to a foldable monoid in functional programming to allow easy aggregation of errors when creating nested domain objects.

# Usage
Using domain primitives with external libraries should be as smoothly as possible. Implicit conversion operators enable domain primitives to be used everywhere where the underlying type can be used. The DebuggerDisplay attribute allows easy viewing of the domain type and the underlying value when debugging.
