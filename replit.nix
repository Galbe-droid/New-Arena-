{ pkgs, legacyPolygott }: {
	deps = [
		pkgs.dotnet-sdk
    pkgs.omnisharp-roslyn
	] ++ legacyPolygott;
}