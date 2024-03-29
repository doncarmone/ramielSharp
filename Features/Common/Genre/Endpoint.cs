﻿using FastEndpoints;

namespace Genres;

sealed class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Get("/genres");
    }

    public override Task HandleAsync(Request req, CancellationToken ct)
    {
        return SendOkAsync(Response, ct);
    }
}