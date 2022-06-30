class InchToPointConvertor {
    const int POINTS_PER_INCH=72;
    static float convertToPoints(float inch) {
        return inch * POINTS_PER_INCH;
    }
}
